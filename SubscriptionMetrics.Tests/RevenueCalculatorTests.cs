using SubscriptionMetrics.App;
using Xunit;

namespace SubscriptionMetrics.Tests;

public class RevenueCalculatorTests
{
    [Fact]
    public void Calculate_ReturnsCorrectActiveMrrAndChurn()
    {
        var lastMonth = new[]
        {
            new CustomerSubscription("CUST-001", 50, true),
            new CustomerSubscription("CUST-002", 100, true)
        };

        var thisMonth = new[]
        {
            new CustomerSubscription("CUST-001", 50, true),   // still active
            new CustomerSubscription("CUST-002", 100, false), // churned
            new CustomerSubscription("CUST-003", 75, true)    // new
        };

        var summary = RevenueCalculator.Calculate(lastMonth, thisMonth);

        Assert.Equal(125m, summary.ActiveMrr);       // 50 + 75
        Assert.Equal(25m, summary.ChurnedRevenue);  // CUST-002 churned
        Assert.Equal(100m, summary.NetMrr);           // 125 - 100
    }

    [Fact]
    public void Ctor_ThrowsForNegativeAmount()
    {
        Assert.Throws<ArgumentException>(() =>
            new CustomerSubscription("CUST-001", -10, true));
    }
}
