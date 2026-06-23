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

    [Fact]
    public void Scanning_single_B_returns_30()
    {
        var checkout = new Checkout();
        checkout.Scan("B");
        Assert.Equal(30, checkout.Total());
    }

    [Fact]
    public void Scanning_single_c_returns_20()
    {
        var checkout = new Checkout();
        checkout.Scan("C");
        Assert.Equal(20, checkout.Total());
    }

    [Fact]
    public void Scanning_single_d_returns_15()
    {
        var checkout = new Checkout();
        checkout.Scan("D");
        Assert.Equal(15, checkout.Total());
    }

    [Fact]
    public void Three_As_cost_130()
    {
        var checkout = new Checkout();
        checkout.Scan("A");
        checkout.Scan("A");
        checkout.Scan("A");
        Assert.Equal(130, checkout.Total());
    }

    [Fact]
    public void Two_Bs_cost_45()
    {
        var checkout = new Checkout();
        checkout.Scan("B");
        checkout.Scan("B");
        Assert.Equal(45, checkout.Total());
    }

    [Fact]
    public void Scanning_A_and_B_returns_80()
    {
        var checkout = new Checkout();
        checkout.Scan("A");
        checkout.Scan("B");
        Assert.Equal(80, checkout.Total());
    }

    [Fact]
    public void Scanning_A_B_A_returns_130()
    {
        var checkout = new Checkout();
        checkout.Scan("A");
        checkout.Scan("B");
        checkout.Scan("A");
        Assert.Equal(130, checkout.Total());
    }
    [Fact]
    public void Scanning_multiple_As_and_Bs_returns_correct_amount()
    {
        var checkout = new Checkout();
        checkout.Scan("A");
        checkout.Scan("B");
        checkout.Scan("A");
        checkout.Scan("A");
        checkout.Scan("B");
        checkout.Scan("A");
        Assert.Equal(225, checkout.Total());
    }
}