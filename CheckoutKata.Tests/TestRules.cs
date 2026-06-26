namespace CheckoutKata.Tests;

public static class TestRules
{
    public static readonly IReadOnlyDictionary<string, PricingRule> Default =
        new Dictionary<string, PricingRule>
        {
            ["A"] = new PricingRule(51.99m, 3, 130m),
            ["B"] = new PricingRule(30.50m, 2, 45m),
            ["C"] = new PricingRule(20.99m, 1, 17.99m),
            ["D"] = new PricingRule(15.99m),
        };
}