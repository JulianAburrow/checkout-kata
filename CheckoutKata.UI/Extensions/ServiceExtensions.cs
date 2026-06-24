namespace CheckoutKata.UI.Extensions;

public static class ServiceExtensions
{
    public static void AddDependencies(this IServiceCollection services)
    {
        services.AddScoped<ICheckout, Checkout>();
        services.AddSingleton<ISkuCatalogue, SkuCatalogue>();

    }
}
