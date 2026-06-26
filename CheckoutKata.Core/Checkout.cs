namespace CheckoutKata.Core;

public class Checkout(IReadOnlyDictionary<string, PricingRule> rules) : ICheckout
{
    private decimal _total = 0;

    public readonly Dictionary<string, int> _counts = [];

    private readonly List<string> _scannedItems = [];

    public IReadOnlyList<string> ScannedItems => _scannedItems;

    public void Scan(string item)
    {
        _scannedItems.Add(item);

        if (!_counts.ContainsKey(item)) {
            _counts[item] = 0;
        }

        _counts[item]++;

        RecalculateTotal();
    }

    private void RecalculateTotal()
    {
        _total = 0;

        foreach (var (sku, count) in _counts)
        {
            var rule = rules[sku];

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

    public decimal GetTotalPrice() => _total;

    public void RemoveLast()
    {
        if (_scannedItems.Count == 0)
            return;

        var last = _scannedItems[^1];
        _scannedItems.RemoveAt(_scannedItems.Count - 1);

        // decrement count
        _counts[last]--;

        // if count hits zero, remove the key entirely
        if (_counts[last] == 0)
            _counts.Remove(last);

        RecalculateTotal();
    }

    public void ClearAll()
    {
        _scannedItems.Clear();
        _counts.Clear();
        RecalculateTotal();
    }

    public void RemoveOne(string sku)
    {
        if (_scannedItems.Remove(sku))
        {
            _counts[sku]--;
            if (_counts[sku] == 0)
                _counts.Remove(sku);

            RecalculateTotal();
        }
    }
}
