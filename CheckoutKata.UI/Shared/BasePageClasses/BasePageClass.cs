namespace CheckoutKata.UI.Shared.BasePageClasses;

public class BasePageClass : ComponentBase
{
    [Inject] protected ISkuCatalogue SkuCatalogue { get; set; } = null!;
}
