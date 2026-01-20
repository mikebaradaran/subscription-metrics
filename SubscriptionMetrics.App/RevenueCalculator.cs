namespace SubscriptionMetrics.App;

public class RevenueSummary
{
    public decimal ActiveMrr { get; }
    public decimal ChurnedRevenue { get; }
    public decimal NetMrr => ActiveMrr - ChurnedRevenue;

    public RevenueSummary(decimal activeMrr, decimal churnedRevenue)
    {
        ActiveMrr = activeMrr;
        ChurnedRevenue = churnedRevenue;
    }
}

public static class RevenueCalculator
{
    public static RevenueSummary Calculate(
			IEnumerable<CustomerSubscription> subscriptionsBefore,
IEnumerable<CustomerSubscription> subscriptionsAfter)
    {
        var beforeActive = subscriptionsBefore.Where(s => s.IsActive).Sum(s => 									s.MonthlyAmount);
        var afterActive = subscriptionsAfter.Where(s => s.IsActive).Sum(s => 										s.MonthlyAmount);

        var churnedRevenue = beforeActive - afterActive;
        if (churnedRevenue < 0) 
			churnedRevenue = 0;

        return new RevenueSummary(afterActive, churnedRevenue);
    }
}

