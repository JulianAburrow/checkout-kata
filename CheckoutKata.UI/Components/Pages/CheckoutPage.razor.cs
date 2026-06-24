namespace CheckoutKata.UI.Components.Pages;

public partial class CheckoutPage
{
    [Inject] private ICheckout Checkout { get; set; } = null!;

    private Dictionary<string, int> GroupedItems =>
        Checkout.ScannedItems
            .GroupBy(x => x)
            .ToDictionary(g => g.Key, g => g.Count());

    private int Total;

    private readonly List<SkuCard> Skus =
    [
        new("A", 50, new SkuOffer(3, 130)),
        new("B", 30, new SkuOffer(2, 45)),
        new("C", 20, null),
        new("D", 15, null)
    ];

    void Scan(string code)
    {
        Checkout.Scan(code);
        Total = Checkout.GetTotalPrice();
    }

    private void RemoveLast()
    {
        if (Checkout.ScannedItems.Count > 0)
        {
            Checkout.RemoveLast();
            Total = Checkout.GetTotalPrice();
        }
    }

    private void ClearAll()
    {
        Checkout.ClearAll();
        Total = Checkout.GetTotalPrice();
    }
}