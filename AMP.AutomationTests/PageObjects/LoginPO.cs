namespace AMP.AutomationTests.PageObjects
{
    public class LoginPO
    {
        private readonly IPage _page;
        private ILocator UsernameField => _page.GetByPlaceholder("Username");
        private ILocator PasswordField => _page.GetByPlaceholder("Password");
        private ILocator LoginButton => _page.GetByRole(AriaRole.Button, new() { Name = "Login" });
        public ILocator ErrorMessage => _page.Locator("[data-test='error']");

        public LoginPO(IPage page) { _page = page; }

        public async Task LoginAsAsync(string username, string password)
        {
            await UsernameField.FillAsync(username);
            await PasswordField.FillAsync(password);
            await LoginButton.ClickAsync();
        }
    }
}