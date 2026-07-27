namespace AMP.AutomationTests.Tests
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        private LoginPO _loginPage;
        private InventoryPO _inventoryPage;

        [SetUp]
        public void InitializePages()
        {
            _loginPage = new LoginPO(Page);
            _inventoryPage = new InventoryPO(Page);
        }

        [Test]
        [Property("TestId", "TC-LOGIN-001")]
        [Property("Priority", "P0")]
        public async Task Login_WithValidCredentials_DisplaysInventoryPage()
        {
            var user = TestDataReader.GetData("Users", "StandardUser");
            await _loginPage.LoginAsAsync(user["Username"], user["Password"]);
            await _expect.HasUrlAsync(Page, $"{BaseUrl}/inventory.html");
            await _expect.HasTextAsync(_inventoryPage.PageTitle, "Products");
        }

        [Test]
        [Property("TestId", "TC-LOGIN-002")]
        [Property("Priority", "P0")]
        public async Task Login_WithLockedOutUser_DisplaysLockedOutError()
        {
            var user = TestDataReader.GetData("Users", "LockedOutUser");

            await _loginPage.LoginAsAsync(user["Username"], user["Password"]);
            await _expect.IsVisibleAsync(_loginPage.ErrorMessage);
            await _expect.ContainsTextAsync(_loginPage.ErrorMessage, "Sorry, this user has been locked out.");
        }

        [Test]
        [Property("TestId", "TS-LOGIN-007")]
        [Property("Priority", "P1")]
        public async Task Login_WithInvalidCredentials_DisplaysAuthenticationError()
        {
            var user = TestDataReader.GetData("Users", "InvalidUser");
            await _loginPage.LoginAsAsync(user["Username"], user["Password"]);
            await _expect.IsVisibleAsync(_loginPage.ErrorMessage);
            await _expect.ContainsTextAsync(_loginPage.ErrorMessage, "Username and password do not match");
        }
    }
}