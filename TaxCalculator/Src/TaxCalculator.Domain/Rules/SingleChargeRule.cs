using TaxCalculator.Domain.Entities;

namespace TaxCalculator.Domain.Rules;

public class SingleChargeRule : ITravelRule
{
    public bool IsApplicable(VehicleEntry entry, TaxCalculationContext context)
    {
        if (!context.PaidInfo.Any())
            return false;

        if (context.PaidInfo.Count == 1)
        {
            UpdateLastPaidInfo(context.PaidInfo.Last());
            return false;
        }

        var lastPaid = GetLastPaidEntry(context);

        if (lastPaid is null)
            return false;

        if (IsWithinSingleChargeWindow(entry.EntryTime, lastPaid.EntryTime)) return true;

        ResetPaidInfo(context.PaidInfo);
        UpdateLastPaidInfo(context.PaidInfo.Last());

        return false;
    }

    public void CalculateTax(VehicleEntry entry, TaxCalculationContext context)
    {
        var lastSuccessPaid = context.PaidInfo.Single(s => s.IsLastPaid);
        var lastPaid = context.PaidInfo.Last();
        lastPaid.IsPaid = false;


        if (lastPaid.Amount > lastSuccessPaid.Amount)
                lastSuccessPaid.Amount = lastPaid.Amount;

        context.CurrentTaxAmount = 0;
    
        Console.WriteLine("SingleChargeRule is fired");

    }

    private void UpdateLastPaidInfo(EntryPaidInfo paidInfo)
    {
        paidInfo.IsLastPaid = true;
    }

    private void ResetPaidInfo(List<EntryPaidInfo> paidInfoList)
    {
        paidInfoList.ForEach(info => info.IsLastPaid = false);
    }

    private EntryPaidInfo GetLastPaidEntry(TaxCalculationContext context)
    {
        return context.PaidInfo.SingleOrDefault(info => info.IsLastPaid);
    }

    private bool IsWithinSingleChargeWindow(DateTime entryTime, DateTime lastPaidTime)
    {
        return (entryTime - lastPaidTime).TotalMinutes <= 60;
    }
}
//public class SingleChargeRule : ITravelRule
//{

//public bool IsApplicable(VehicleEntry entry, TaxCalculationContext context)
//{

//    if (context.PaidInfo.Count == 1)
//    {
//        context.PaidInfo.Last().IsLastPaid = true;
//        return false;
//    }


//    var lastPaid = context.PaidInfo.SingleOrDefault(s => s.IsLastPaid);

//    if (lastPaid is null) return false;

//    if ((entry.EntryTime - lastPaid.EntryTime).TotalMinutes <= 60)
//    {
//        return true;
//    }

//    context.PaidInfo.ForEach(f => f.IsLastPaid = false);
//    context.PaidInfo.Last().IsLastPaid = true;
//    return false;

//}

//public decimal CalculateTax(VehicleEntry entry, TaxCalculationContext context)
//{
//    var lastSuccessPaid = context.PaidInfo.Single(s => s.IsLastPaid);
//    var lastPaid = context.PaidInfo.Last();
//    lastPaid.IsPaid = false;

//    if (lastPaid.Amount > lastSuccessPaid.Amount)
//    {
//        lastSuccessPaid.Amount = lastPaid.Amount;
//    }

//    context.CurrentTaxAmount = 0;
//    Console.WriteLine($"SingleChargeRule is fired");


//    return context.CurrentTaxAmount;
//}
//}
