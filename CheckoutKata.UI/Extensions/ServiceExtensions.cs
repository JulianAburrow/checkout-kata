namespace CheckoutKata.UI.Extensions;

public static class ServiceExtensions
{
    public static void AddDependencies(this IServiceCollection services)
    {
        // 1. Register the pricing rules ONCE
        var rules = new Dictionary<string, PricingRule>
        {
            ["A"] = new PricingRule(51.99m, 1, 39.99m),
            ["B"] = new PricingRule(30.50m, 2, 45m),
            ["C"] = new PricingRule(20.99m, 1, 17.99m),
            ["D"] = new PricingRule(15.99m),
        };

        services.AddSingleton<IReadOnlyDictionary<string, PricingRule>>(rules);

        // 2. Register the checkout (which will receive the same rules)
        services.AddScoped<ICheckout, Checkout>();

        // 3. Register the catalogue (which will also receive the same rules)
        services.AddSingleton<ISkuCatalogue, SkuCatalogue>();
    }
}
