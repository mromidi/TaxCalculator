namespace TaxCalculator.Application.Services.Abstractions
{
    public interface ICalculateTaxService
    {
        Task CalculateTaxForYear(int year, string cityName);
    }
}
