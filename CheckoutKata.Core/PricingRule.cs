namespace CheckoutKata.Core;

public class PricingRule(decimal unitPrice, int offerQuantity = 0, decimal offerPrice = 0)
{
    public decimal UnitPrice { get; } = unitPrice;

    public int OfferQuantity { get; } = offerQuantity;

    public decimal OfferPrice { get; } = offerPrice;
}
