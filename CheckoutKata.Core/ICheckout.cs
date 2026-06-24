namespace CheckoutKata.Core;

public interface ICheckout
{
    void Scan(string item);

    int GetTotalPrice();

    IReadOnlyList<string> ScannedItems { get; }

    void RemoveLast();

    void ClearAll();
    void RemoveOne(string sku);
}
