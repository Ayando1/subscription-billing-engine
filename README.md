# Subscription & Billing Engine (.NET / C#)

A robust, object-oriented subscription management and billing system designed to simulate real-world SaaS billing architectures (e.g., Stripe, Spotify), featuring automated grace period enforcement and dynamic discount logic.

---

## Key Features & Business Rules

* **Dynamic Pricing Engine**: Automated annual discount calculation (e.g., applying a 15% discount for 12-month advance commitments).
* **Financial Precision**: Eliminates floating-point rounding errors by utilizing the 128-bit `decimal` data type across all monetary calculations.
* **Grace Period Lifecycle**:
  * **1–6 days overdue**: Subscription access remains active while transitioning to `PastDue` status for payment retries.
  * **7+ days overdue**: Automatic cancellation (`Canceled`) to prevent revenue leakage.
* **Domain-Driven OOP Design**: Strict encapsulation, strongly-typed `enum` state management, and separation of concerns between domain entities and business services.

---

## Project Structure

```text
├── Models/
│   ├── Plan.cs                 # Subscription tier definition and base pricing
│   ├── Customer.cs             # Customer identity and contact profile
│   ├── SubscriptionStatus.cs   # Enum states (Active, PastDue, Canceled)
│   ├── Subscription.cs         # Lifecycle evaluation and grace period business logic
│   └── Invoice.cs              # Generated billing document model
├── Services/
│   └── BillingService.cs       # Calculation engine and invoice generation
└── Program.cs                  # Interactive execution demo & lifecycle simulation
```

---

## Getting Started

### Prerequisites
* [.NET 8.0 SDK](https://dotnet.microsoft.com/download) or higher

### Installation & Run
1. Clone the repository:
   ```bash
   git clone [https://github.com/YOUR_USERNAME/subscription-billing-engine.git](https://github.com/YOUR_USERNAME/subscription-billing-engine.git)
   cd subscription-billing-engine
   ```
2. Run the application:
   ```bash
   dotnet run
   ```