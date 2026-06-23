namespace CheckoutKata.Tests;

public class CheckoutTests
{
    [Fact]
    public void Scanning_single_A_returns_50()
    {
        var checkout = new Checkout();
        checkout.Scan("A");
        Assert.Equal(50, checkout.Total());
    }

    [Fact]
    public void Scanning_two_As_returns_100()
    {
        var checkout = new Checkout();
        checkout.Scan("A");
        checkout.Scan("A");
        Assert.Equal(100, checkout.Total());
    }
}