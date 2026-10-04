namespace TaxCalculator.Application.Services.Abstractions
{
    public interface ICalculateTaxService
    {
        Task<List<string>> CalculateTaxForYear(int year, string cityName);
    }
}
