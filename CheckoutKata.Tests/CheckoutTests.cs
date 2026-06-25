namespace CheckoutKata.Tests;

public class CheckoutTests
{
    [Fact]
    public void Scanning_single_A_returns_50()
    {
        var checkout = new Checkout(TestRules.Default);
        checkout.Scan("A");
        Assert.Equal(50, checkout.GetTotalPrice());
    }

    [Fact]
    public void Scanning_two_As_returns_100()
    {
        var checkout = new Checkout(TestRules.Default);
        checkout.Scan("A");
        checkout.Scan("A");
        Assert.Equal(100, checkout.GetTotalPrice());
    }

    [Fact]
    public void Scanning_single_B_returns_30()
    {
        var checkout = new Checkout(TestRules.Default);
        checkout.Scan("B");
        Assert.Equal(30, checkout.GetTotalPrice());
    }

    [Fact]
    public void Scanning_single_c_returns_20()
    {
        var checkout = new Checkout(TestRules.Default);
        checkout.Scan("C");
        Assert.Equal(20, checkout.GetTotalPrice());
    }

    [Fact]
    public void Scanning_single_d_returns_15()
    {
        var checkout = new Checkout(TestRules.Default);
        checkout.Scan("D");
        Assert.Equal(15, checkout.GetTotalPrice());
    }

    [Fact]
    public void Three_As_cost_130()
    {
        var checkout = new Checkout(TestRules.Default);
        checkout.Scan("A");
        checkout.Scan("A");
        checkout.Scan("A");
        Assert.Equal(130, checkout.GetTotalPrice());
    }

    [Fact]
    public void Two_Bs_cost_45()
    {
        var checkout = new Checkout(TestRules.Default);
        checkout.Scan("B");
        checkout.Scan("B");
        Assert.Equal(45, checkout.GetTotalPrice());
    }

    [Fact]
    public void Scanning_A_and_B_returns_80()
    {
        var checkout = new Checkout(TestRules.Default);
        checkout.Scan("A");
        checkout.Scan("B");
        Assert.Equal(80, checkout.GetTotalPrice());
    }

    [Fact]
    public void Scanning_A_B_A_returns_130()
    {
        var checkout = new Checkout(TestRules.Default);
        checkout.Scan("A");
        checkout.Scan("B");
        checkout.Scan("A");
        Assert.Equal(130, checkout.GetTotalPrice());
    }
    [Fact]
    public void Scanning_multiple_As_and_Bs_returns_correct_amount()
    {
        var checkout = new Checkout(TestRules.Default);
        checkout.Scan("A");
        checkout.Scan("B");
        checkout.Scan("A");
        checkout.Scan("A");
        checkout.Scan("B");
        checkout.Scan("A");
        Assert.Equal(225, checkout.GetTotalPrice());
    }

    [Fact]
    public void Order_does_not_affect_total()
    {
        var checkout1 = new Checkout(TestRules.Default);
        checkout1.Scan("A");
        checkout1.Scan("B");
        checkout1.Scan("A");

        var checkout2 = new Checkout(TestRules.Default);
        checkout2.Scan("A");
        checkout2.Scan("A");
        checkout2.Scan("B");

        Assert.Equal(checkout1.GetTotalPrice(), checkout2.GetTotalPrice());
    }

    [Fact]
    public void Large_basket_calculates_correctly()
    {
        var checkout = new Checkout(TestRules.Default);

        for (int i = 0; i < 10; i++)
            checkout.Scan("A"); // 3-for-130 applied 3 times + 1 extra

        Assert.Equal(130 * 3 + 50, checkout.GetTotalPrice());
    }
}