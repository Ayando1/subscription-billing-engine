using SubscriptionBillingEngine.Models;

namespace SubscriptionBillingEngine.Services;

public static class BillingService
{
    public static decimal CalculateBillingAmount(Plan plan, int months)
    {
        if (months <= 0)
            throw new ArgumentException("A feliratkozási időnek legalább 1 hónapnak kell lennie.");

        var basePrice = plan.MonthlyPrice * months;

        // 12 hónap vagy afelett 15% kedvezmény jár
        if (months >= 12)
            return basePrice * 0.85m;

        return basePrice;
    }

    public static Invoice GenerateInvoice(Customer customer, Plan plan, int months)
    {
        var total = CalculateBillingAmount(plan, months);

        return new Invoice
        {
            Id = 1,
            Customer = customer,
            TotalAmount = total,
            IssueDate = DateTime.UtcNow,
            IsPaid = true
        };
    }
}