namespace CheckoutKata.Core;

public interface ICheckout
{
    void Scan(string item);

    decimal GetTotalPrice();

    IReadOnlyList<string> ScannedItems { get; }

    void RemoveLast();

    void ClearAll();

    void RemoveOne(string sku);
}
