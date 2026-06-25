namespace CheckoutKata.Tests;

public static class TestRules
{
    public static readonly IReadOnlyDictionary<string, PricingRule> Default =
        new Dictionary<string, PricingRule>
        {
            ["A"] = new PricingRule(50, 3, 130),
            ["B"] = new PricingRule(30, 2, 45),
            ["C"] = new PricingRule(20),
            ["D"] = new PricingRule(15),
        };
}
