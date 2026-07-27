namespace AMP.AutomationTests.PageObjects
{
    public class CheckoutPO
    {
        private readonly IPage _page;
        private ILocator FirstNameField => _page.GetByPlaceholder("First Name");
        private ILocator LastNameField => _page.GetByPlaceholder("Last Name");
        private ILocator PostalCodeField => _page.GetByPlaceholder("Zip/Postal Code");
        private ILocator ContinueButton => _page.GetByRole(AriaRole.Button, new() { Name = "Continue" });
        private ILocator FinishButton => _page.GetByRole(AriaRole.Button, new() { Name = "Finish" });
        public ILocator OrderConfirmationHeader => _page.Locator(".complete-header");

        public CheckoutPO(IPage page) { _page = page; }

        public async Task FillCheckoutInformationAsync(string firstName, string lastName, string postalCode)
        {
            await FirstNameField.FillAsync(firstName);
            await LastNameField.FillAsync(lastName);
            await PostalCodeField.FillAsync(postalCode);
        }

        public async Task ClickContinueAsync()
        {
            await ContinueButton.ClickAsync();
        }

        public async Task ClickFinishAsync()
        {
            await FinishButton.ClickAsync();
        }
    }
}