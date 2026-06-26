namespace CheckoutKata.Tests;

public class CheckoutTests
{
    protected static IReadOnlyDictionary<string, PricingRule> Rules = TestRules.Default;

    [Fact]
    public void Scanning_single_A_returns_correct_amount()
    {
        var checkout = new Checkout(Rules);
        checkout.Scan("A");
        var expected = TestHelper.CalculateExpectedTotal(Rules, "A");
        Assert.Equal(expected, checkout.GetTotalPrice());
    }

    [Fact]
    public void Scanning_two_As_returns_correct_amount()
    {
        var checkout = new Checkout(Rules);
        var itemsToScan = new[] { "A", "A" };

        foreach (var item in itemsToScan)
        {
            checkout.Scan(item);
        }

        var expected = TestHelper.CalculateExpectedTotal(Rules, [.. itemsToScan]);

        Assert.Equal(expected, checkout.GetTotalPrice());
    }

    [Fact]
    public void Scanning_single_B_returns_correct_amount()
    {
        var checkout = new Checkout(Rules);
        checkout.Scan("B");

        var expected = TestHelper.CalculateExpectedTotal(Rules, "B");

        Assert.Equal(expected, checkout.GetTotalPrice());
    }

    [Fact]
    public void Scanning_single_C_returns_correct_amount()
    {
        var checkout = new Checkout(Rules);
        checkout.Scan("C");

        var expected = TestHelper.CalculateExpectedTotal(Rules, "C");

        Assert.Equal(expected, checkout.GetTotalPrice());
    }

    [Fact]
    public void Scanning_single_D_returns_correct_amount()
    {
        var checkout = new Checkout(Rules);
        checkout.Scan("D");

        var expected = TestHelper.CalculateExpectedTotal(Rules, "D");

        Assert.Equal(expected, checkout.GetTotalPrice());
    }

    [Fact]
    public void Three_As_cost_correct_amount()
    {
        var checkout = new Checkout(Rules);
        var itemsToScan = new[] { "A", "A", "A" };

        foreach (var item in itemsToScan)
        {
            checkout.Scan(item);
        }

        var expected = TestHelper.CalculateExpectedTotal(Rules, [.. itemsToScan]);

        Assert.Equal(expected, checkout.GetTotalPrice());
    }

    [Fact]
    public void Two_Bs_cost_correct_amount()
    {
        var checkout = new Checkout(Rules);
        var itemsToScan = new[] { "B", "B" };

        foreach (var item in itemsToScan)
        {
            checkout.Scan(item);
        }

        var expected = TestHelper.CalculateExpectedTotal(Rules, [.. itemsToScan]);

        Assert.Equal(expected, checkout.GetTotalPrice());
    }

    [Fact]
    public void Scanning_A_and_B_returns_correct_amount()
    {
        var checkout = new Checkout(Rules);
        var itemsToScan = new[] { "A", "B" };

        foreach (var item in itemsToScan)
        {
            checkout.Scan(item);
        }

        var expected = TestHelper.CalculateExpectedTotal(Rules, [.. itemsToScan]);
    
        Assert.Equal(expected, checkout.GetTotalPrice());
    }

    [Fact]
    public void Scanning_A_B_A_returns_correct_amount()
    {
        var checkout = new Checkout(Rules);
        var itemsToScan = new [] { "A", "B", "A" };

        foreach (var item in itemsToScan)
        {
            checkout.Scan(item);
        }

        var expected = TestHelper.CalculateExpectedTotal(Rules, [.. itemsToScan]);

        Assert.Equal(expected, checkout.GetTotalPrice());
    }

    [Fact]
    public void Scanning_multiple_As_and_Bs_returns_correct_amount()
    {
        var checkout = new Checkout(Rules);

        var itemsToScan = new[] { "A", "B", "A", "A", "B", "A" };

        foreach (var item in itemsToScan)
        {
            checkout.Scan(item);
        }

        var expected = TestHelper.CalculateExpectedTotal(Rules, [ .. itemsToScan]);

        Assert.Equal(expected, checkout.GetTotalPrice());
    }

    [Fact]
    public void Order_does_not_affect_total()
    {
        var checkout1 = new Checkout(Rules);
        checkout1.Scan("A");
        checkout1.Scan("B");
        checkout1.Scan("A");

        var checkout2 = new Checkout(Rules);
        checkout2.Scan("A");
        checkout2.Scan("A");
        checkout2.Scan("B");

        Assert.Equal(checkout1.GetTotalPrice(), checkout2.GetTotalPrice());
    }

    [Fact]
    public void Large_basket_calculates_correctly()
    {
        var checkout = new Checkout(Rules);

        for (int i = 0; i < 10; i++)
            checkout.Scan("A");

        // Compute expected using the Rules
        var ruleA = Rules["A"];
        var offerBundles = 10 / ruleA.OfferQuantity;
        var remainder = 10 % ruleA.OfferQuantity;

        var expected =
            offerBundles * ruleA.OfferPrice +
            remainder * ruleA.UnitPrice;

        Assert.Equal(expected, checkout.GetTotalPrice());
    }
}