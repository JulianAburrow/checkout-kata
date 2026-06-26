namespace CheckoutKata.Tests;

public static class TestHelper
{
    public static decimal CalculateExpectedTotal(
        IReadOnlyDictionary<string, PricingRule> rules,
        params string[] items)
    {
        // Count items
        var counts = items
            .GroupBy(x => x)
            .ToDictionary(g => g.Key, g => g.Count());

        decimal total = 0;

        foreach (var kvp in counts)
        {
            var sku = kvp.Key;
            var count = kvp.Value;
            var rule = rules[sku];

            if (rule.OfferQuantity > 0 && rule.OfferPrice > 0)
            {
                var bundles = count / rule.OfferQuantity;
                var remainder = count % rule.OfferQuantity;

                total += bundles * rule.OfferPrice;
                total += remainder * rule.UnitPrice;
            }
            else
            {
                total += count * rule.UnitPrice;
            }
        }

        return total;
    }
}
