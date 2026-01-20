using SubscriptionMetrics.App;

var lastMonth = new[]
{
    new CustomerSubscription("CUST-001", 50, true),
    new CustomerSubscription("CUST-002", 100, true),
    new CustomerSubscription("CUST-003", 75, true)
};

var thisMonth = new[]
{
    new CustomerSubscription("CUST-001", 50, true),
    new CustomerSubscription("CUST-002", 100, false), // churned
    new CustomerSubscription("CUST-004", 120, true)   // new customer
};

var summary = RevenueCalculator.Calculate(lastMonth, thisMonth);

Console.WriteLine("Subscription revenue summary");
Console.WriteLine("----------------------------");
Console.WriteLine($"Active MRR:        {summary.ActiveMrr:C}");
Console.WriteLine($"Churned revenue:   {summary.ChurnedRevenue:C}");
Console.WriteLine($"Net MRR:           {summary.NetMrr:C}");
