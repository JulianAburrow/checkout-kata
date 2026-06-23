namespace CheckoutKata.Core;

public class Checkout
{
    private int _total = 0;

    private readonly Dictionary<string, PricingRule> _rules = new()
    {
        ["A"] = new PricingRule(50, 3, 130),
        ["B"] = new PricingRule(30, 2, 45),
        ["C"] = new PricingRule(20),
        ["D"] = new PricingRule(15),
    };

    private readonly Dictionary<string, int> _counts = new();

    public void Scan(string sku)
    {
        if (!_counts.ContainsKey(sku)) {
            _counts[sku] = 0;
        }

        _counts[sku]++;

        RecalculateTotal();
    }

    private void RecalculateTotal()
    {
        _total = 0;

        foreach (var (sku, count) in _counts)
        {
            var rule = _rules[sku];

            if (rule.OfferQuantity > 0)
            {
                _total += (count / rule.OfferQuantity) * rule.OfferPrice;
                _total += (count % rule.OfferQuantity) * rule.UnitPrice;
            }
            else
            {
                _total += count * rule.UnitPrice;
            }
        }
    }

    public int Total() => _total;
}
