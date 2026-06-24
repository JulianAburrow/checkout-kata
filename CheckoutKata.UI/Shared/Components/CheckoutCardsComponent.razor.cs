namespace CheckoutKata.UI.Shared.Components;

public partial class CheckoutCardsComponent
{
    [Parameter] public List<SkuCard> Skus { get; set; } = default!;

    [Parameter] public EventCallback<string> OnScan { get; set; }
}