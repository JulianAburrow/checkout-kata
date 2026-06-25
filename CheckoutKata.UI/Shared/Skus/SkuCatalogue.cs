namespace CheckoutKata.UI.Shared.Skus;

public interface ISkuCatalogue
{
    IReadOnlyList<SkuCard> Skus { get; }
}

public class SkuCatalogue : ISkuCatalogue
{
    public IReadOnlyList<SkuCard> Skus { get; }

    public SkuCatalogue(IReadOnlyDictionary<string, PricingRule> rules)
    {
        Skus = rules.Select(r =>
            new SkuCard(
                r.Key,
                r.Value.UnitPrice,
                r.Value.OfferQuantity > 0
                    ? new SkuOffer(r.Value.OfferQuantity, r.Value.OfferPrice)
                    : null
            )
        ).ToList();
    }
}
