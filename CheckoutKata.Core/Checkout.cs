namespace CheckoutKata.Core;

public class Checkout
{
    private int _total = 0;

    public void Scan(string sku)
    {
        if (sku == "A")
            _total += 50;
    }

    public int Total() => _total;
}
