namespace AMP.AutomationTests.Tests
{
    [TestFixture]
    public class CheckoutTests : TestBase
    {
        private LoginPO _loginPage;
        private InventoryPO _inventoryPage;
        private CartPO _cartPage;
        private CheckoutPO _checkoutPage;

        [SetUp]
        public async Task PrepareCheckoutAsync()
        {
            _loginPage = new LoginPO(Page);
            _inventoryPage = new InventoryPO(Page);
            _cartPage = new CartPO(Page);
            _checkoutPage = new CheckoutPO(Page);

            var user = TestDataReader.GetData("Users", "StandardUser");

            await _loginPage.LoginAsAsync(user["Username"], user["Password"]);
            await _inventoryPage.AddFirstProductToCartAsync();
            await _inventoryPage.OpenCartAsync();
        }

        [Test]
        [Property("TestId", "TC-CHECKOUT-001")]
        [Property("Priority", "P0")]
        public async Task CompleteCheckout_WithValidInformation_DisplaysOrderConfirmation()
        {
            var customer = TestDataReader.GetData("Checkout", "ValidCustomer");
            await _cartPage.ClickCheckoutAsync();
            await _checkoutPage.FillCheckoutInformationAsync(customer["FirstName"], customer["LastName"], customer["PostalCode"]);
            await _checkoutPage.ClickContinueAsync();
            await _checkoutPage.ClickFinishAsync();
            await _expect.IsVisibleAsync(_checkoutPage.OrderConfirmationHeader);
            await _expect.ContainsTextAsync(_checkoutPage.OrderConfirmationHeader, "Thank you for your order!");
        }
    }
}