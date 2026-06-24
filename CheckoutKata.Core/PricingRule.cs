namespace CheckoutKata.Core;

public class PricingRule(int unitPrice, int offerQuantity = 0, int offerPrice = 0)
{
    public int UnitPrice { get; } = unitPrice;

    public int OfferQuantity { get; } = offerQuantity;

    public int OfferPrice { get; } = offerPrice;
}
