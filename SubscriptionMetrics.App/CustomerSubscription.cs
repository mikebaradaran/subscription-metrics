namespace SubscriptionMetrics.App;

public class CustomerSubscription
{
    public string CustomerId { get; }
    public decimal MonthlyAmount { get; }
    public bool IsActive { get; }

    public CustomerSubscription(string customerId, decimal monthlyAmount, 
								bool isActive)
    {
        if (string.IsNullOrWhiteSpace(customerId))
            throw new ArgumentException("CustomerId is required", 										nameof(customerId));

        if (monthlyAmount < 0)
            throw new ArgumentException("Monthly amount cannot be negative", 									nameof(monthlyAmount));

        CustomerId = customerId;
        MonthlyAmount = monthlyAmount;
        IsActive = isActive;
    }
}
