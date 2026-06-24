namespace CheckoutKata.UI.Shared.Components;

public partial class CheckoutCardsComponent
{
    [Parameter] public IReadOnlyList<SkuCard> Skus { get; set; } = default!;

    [Parameter] public EventCallback<string> OnScan { get; set; }
}