namespace AMP.AutomationTests.PageObjects
{
    public class InventoryPO
    {
        private readonly IPage _page;
        private ILocator ProductItems => _page.Locator(".inventory_item");
        private ILocator CartIcon => _page.Locator(".shopping_cart_link");
        public ILocator PageTitle => _page.Locator(".title");

        public InventoryPO(IPage page) { _page = page; }

        public async Task AddFirstProductToCartAsync()
        {
            await ProductItems.First.GetByRole(AriaRole.Button, new() { Name = "Add to cart" }).ClickAsync();
        }

        public async Task OpenCartAsync()
        {
            await CartIcon.ClickAsync();
        }
    }
}