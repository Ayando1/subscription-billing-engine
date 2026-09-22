namespace SubscriptionBillingEngine.Models;

public class Invoice
{
    public int Id { get; set; }
    public Customer Customer { get; set; }
    public decimal TotalAmount { get; set; }
    public DateTime IssueDate { get; set; }
    public bool IsPaid { get; set; }
}