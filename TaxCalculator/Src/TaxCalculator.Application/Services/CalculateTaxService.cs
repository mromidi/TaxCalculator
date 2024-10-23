using TaxCalculator.Application.Dtos;
using TaxCalculator.Application.Services.Abstractions;
using TaxCalculator.Domain.Entities;
using TaxCalculator.Domain.Repositories;
using TaxCalculator.Domain.Rules;

namespace TaxCalculator.Application.Services
{
    public class CalculateTaxService : ICalculateTaxService
    {
        private readonly IVehicleEntryRepository _vehicleEntryRepository;
        private readonly ICityRulesDetailRepository _cityRulesDetailRepository;
        public CalculateTaxService(IVehicleEntryRepository vehicleEntryRepository, ICityRulesDetailRepository cityRulesDetailRepository)
        {
            _vehicleEntryRepository = vehicleEntryRepository;
            _cityRulesDetailRepository = cityRulesDetailRepository;
        }

        public async Task<List<string>> CalculateTaxForYear(int year, string cityName)
        {
            var cityRules = await _cityRulesDetailRepository.GetActiveCityRulesDetail(year, cityName);

            var allEntries = await _vehicleEntryRepository.GetVehicleEntryAsync(year);

            var groupedEntries = GenerateGroupedEntries(allEntries);
            return EntriesTaxProcess(groupedEntries, cityRules);

        }
        private List<string> EntriesTaxProcess(IEnumerable<DateGroup> groupedEntries, CityRulesDetail cityRules)
        {
            var response = new List<string>();
            var rules = GenerateRules(cityRules);

            var ruleEngine = new RuleEngine(rules);

            foreach (var dateGroup in groupedEntries)
            {
                string message = string.Empty;
                message = $"Processing entries for date: {dateGroup.Date}\n";
                response.Add(message);
                response.Add(string.Empty);
                Console.WriteLine(message);

                foreach (var vehicleGroup in dateGroup.Vehicles)
                {
                    var context = new TaxCalculationContext();
                    decimal totalDailyTax = 0;

                    var orderedEntries = vehicleGroup.OrderBy(o => o.EntryTime);

                    foreach (var entry in orderedEntries)
                    {

                        ruleEngine.CalculateTaxAmount(entry, context);


                        totalDailyTax = context.PaidInfo.Where(w => w.IsPaid).Sum(s => s.Amount);

                        if (totalDailyTax > cityRules.MaxDailyTax)
                        {
                            totalDailyTax = cityRules.MaxDailyTax;
                            break;
                        }
                        message = $"Vehicle {entry.VehicleNumber} taxed: SEK {context.CurrentTaxAmount} at {entry.EntryTime}";
                        response.Add(message);
                        Console.WriteLine(message);
                    }
                    message = $"Total tax for vehicle {vehicleGroup.Key} on {dateGroup.Date.ToShortDateString()}: SEK {totalDailyTax}\n";
                    response.Add(message);
                    response.Add(string.Empty);
                    Console.WriteLine(message);
                }
            }
            return response;
        }

        private List<ITravelRule> GenerateRules(CityRulesDetail cityRules)
        {
            return new List<ITravelRule>
            {
                new WeekendAndHolidayRule(cityRules.NonTaxablePeriods),
                new VehicleExemptionRule(cityRules.ExemptVehicles),
                new CalculateTaxRule(cityRules.HourTaxRules),
                new SingleChargeRule()

            };
        }

        private IEnumerable<DateGroup> GenerateGroupedEntries(List<VehicleEntry> allEntries)
        {
            return allEntries
           .GroupBy(entry => entry.EntryTime.Date)
           .Select(group => new DateGroup
           {
               Date = group.Key,
               Vehicles = group.GroupBy(entry => entry.VehicleNumber)
           });
        }
    }
}
