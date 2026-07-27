namespace AMP.AutomationTests.PageObjects
{
    public class CartPO
    {
        private readonly IPage _page;

        private ILocator CheckoutButton => _page.GetByRole(AriaRole.Button, new() { Name = "Checkout" });

        public CartPO(IPage page) { _page = page; }

        public async Task ClickCheckoutAsync()
        {
            await CheckoutButton.ClickAsync();
        }
    }
}