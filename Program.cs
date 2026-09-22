using SubscriptionBillingEngine.Models;
using SubscriptionBillingEngine.Services;

Console.WriteLine("=== ELŐFIZETÉSI ÉS SZÁMLÁZÁSI RENDSZER DEMÓ ===");

// Csomagok és ügyfél létrehozása
var proPlan = new Plan { Id = 1, Name = "Pro Csomag", MonthlyPrice = 4000m };
var customer = new Customer { Id = 101, Name = "Kovács Dániel", Email = "kovacs.daniel@example.com" };

Console.WriteLine($"\n[1] Ügyfél regisztrálva: {customer.Name} ({customer.Email})");
Console.WriteLine($"Kiválasztott csomag: {proPlan.Name} ({proPlan.MonthlyPrice:N0} Ft / hó)");

// Számlázás tesztelése (12 hónap -> 15% kedvezmény)
int months = 12;
var invoice = BillingService.GenerateInvoice(customer, proPlan, months);

Console.WriteLine($"\n[2] Számla kiállítva ({months} hónapra):");
Console.WriteLine($"Összesen fizetendő: {invoice.TotalAmount:N0} Ft (kedvezménnyel)");
Console.WriteLine($"Kiállítás dátuma: {invoice.IssueDate:yyyy-MM-dd HH:mm:ss} UTC");

// Előfizetés és türelmi idő (Grace Period)
var subscription = new Subscription
{
    Id = 1,
    Customer = customer,
    Plan = proPlan,
    StartDate = DateTime.UtcNow.AddMonths(-1),
    NextBillingDate = DateTime.UtcNow.AddDays(-3), // 3 napos tartozás
    Status = SubscriptionStatus.Active
};

Console.WriteLine($"\n[3] Eredeti előfizetés státusza: {subscription.Status}");
Console.WriteLine($"Fizetési határidő: {subscription.NextBillingDate:yyyy-MM-dd} (3 napja lejárt)");

// Státusz frissítése
subscription.UpdatePaymentStatus();
Console.WriteLine($"Státusz frissítés után: {subscription.Status} (Türelmi időszakban!)");

// 10 napos tartozás szimulációja
subscription.NextBillingDate = DateTime.UtcNow.AddDays(-10);
subscription.UpdatePaymentStatus();
Console.WriteLine($"10 nap késedelem utáni státusz: {subscription.Status} (Automatikusan lemondva)");