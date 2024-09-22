using TaxCalculator.Application.Services.Abstractions;
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

        public async Task CalculateTaxForYear(int year, string cityName)
        {
            var cityRules = await _cityRulesDetailRepository.GetActiveCityRulesDetail();

            var allEntries = await _vehicleEntryRepository.GetVehicleEntryAsync(year);

            var groupedEntries = allEntries
           .GroupBy(entry => entry.EntryTime.Date) // Group by date
           .Select(group => new
           {
               Date = group.Key,
               Vehicles = group.GroupBy(entry => entry.VehicleNumber) // Group by vehicle Number
           });

            var rules = new List<ITravelRule>
            {
                new WeekendAndHolidayRule(cityRules.NonTaxablePeriods),
                new VehicleExemptionRule(cityRules.ExemptVehicles),
                new CalculateTaxRule(cityRules.TaxRules),
                new SingleChargeRule()

            };

            var ruleEngine = new RuleEngine(rules);


            foreach (var dateGroup in groupedEntries)
            {
                Console.WriteLine($"Processing entries for date: {dateGroup.Date}");

                foreach (var vehicleGroup in dateGroup.Vehicles)
                {
                    decimal totalDailyTax = 0;

                    var orderedEntries = vehicleGroup.OrderBy(o => o.EntryTime);
                    foreach (var entry in orderedEntries)
                    {
                        var tax = ruleEngine.CalculateTaxAmount(entry);
                        totalDailyTax += tax;
                        if (totalDailyTax > 60)
                        {
                            totalDailyTax = 60;
                            break;
                        }
                        Console.WriteLine($"Vehicle {entry.VehicleNumber} taxed: SEK {tax} at {entry.EntryTime}");
                    }

                    Console.WriteLine($"Total tax for vehicle {vehicleGroup.Key} on {dateGroup.Date}: SEK {totalDailyTax}");
                }
            }
        }

    }
}
