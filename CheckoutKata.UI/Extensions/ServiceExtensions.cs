namespace CheckoutKata.UI.Extensions;

public static class ServiceExtensions
{
    public static void AddDependencies(this IServiceCollection services)
    {
        // 1. Register the pricing rules ONCE
        var rules = new Dictionary<string, PricingRule>
        {
            ["A"] = new PricingRule(50, 3, 130),
            ["B"] = new PricingRule(30, 2, 45),
            ["C"] = new PricingRule(20),
            ["D"] = new PricingRule(15),
        };

        services.AddSingleton<IReadOnlyDictionary<string, PricingRule>>(rules);

        // 2. Register the checkout (which will receive the same rules)
        services.AddScoped<ICheckout, Checkout>();

        // 3. Register the catalogue (which will also receive the same rules)
        services.AddSingleton<ISkuCatalogue, SkuCatalogue>();
    }
}
