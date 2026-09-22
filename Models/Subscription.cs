namespace SubscriptionBillingEngine.Models;

public class Subscription
{
    public int Id { get; set; }
    public Customer Customer { get; set; }
    public Plan Plan { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime NextBillingDate { get; set; }
    public SubscriptionStatus Status { get; set; }

    public void Cancel()
    {
        Status = SubscriptionStatus.Canceled;
    }

    public void UpdatePaymentStatus()
    {
        var overdueDays = (DateTime.UtcNow - NextBillingDate).TotalDays;

        if (overdueDays >= 7)
        {
            Cancel();
        }
        else if (overdueDays > 0)
        {
            Status = SubscriptionStatus.PastDue;
        }
        else
        {
            Status = SubscriptionStatus.Active;
        }
    }
}