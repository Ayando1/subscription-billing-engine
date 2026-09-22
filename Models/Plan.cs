namespace SubscriptionBillingEngine.Models;

public class Plan
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal MonthlyPrice { get; set; }
}