namespace CheckoutKata.UI.Components.Pages;

public partial class CheckoutPage
{
    [Inject] private ICheckout Checkout { get; set; } = null!;

    private ElementReference focusTarget;

    private Dictionary<string, int> GroupedItems =>
        Checkout.ScannedItems
            .GroupBy(x => x)
            .ToDictionary(g => g.Key, g => g.Count());

    private decimal Total;

    private void Scan(string code)
    {
        Checkout.Scan(code);
        GetTotal();
    }

    private void RemoveLast()
    {
        if (Checkout.ScannedItems.Count > 0)
        {
            Checkout.RemoveLast();
            GetTotal();
        }
    }

    private void ClearAll()
    {
        Checkout.ClearAll();
        GetTotal();
    }

    private async Task HandleKey(KeyboardEventArgs e)
    {
        var key = e.Key.ToUpperInvariant();

        if (SkuCatalogue.Skus.Any(s => s.Code == key))
        {
            Scan(key);
            return;
        }

        if (key == "BACKSPACE")
        {
            RemoveLast();
            return;
        }

        if (key == "ESCAPE")
        {
            ClearAll();
        }
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (!firstRender)
            return;

        await focusTarget.FocusAsync();
    }

    private void Increment(string sku) => Scan(sku);

    private void Decrement(string sku)
    {
        Checkout.RemoveOne(sku);
        GetTotal();
    }

    private void GetTotal() => Total = Checkout.GetTotalPrice();
}