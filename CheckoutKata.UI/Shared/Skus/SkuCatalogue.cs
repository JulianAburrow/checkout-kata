namespace CheckoutKata.UI.Shared.Skus;

public interface ISkuCatalogue
{
    IReadOnlyList<SkuCard> Skus { get; }
}

public class SkuCatalogue : ISkuCatalogue
{
    public IReadOnlyList<SkuCard> Skus { get; } =
    [
        new("A", 50, new SkuOffer(3, 130)),
        new("B", 30, new SkuOffer(2, 45)),
        new("C", 20, null),
        new("D", 15, null)
    ];
}