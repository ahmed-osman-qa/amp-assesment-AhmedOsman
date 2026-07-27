namespace AMP.AutomationTests.Helpers
{
    public abstract class TestBase : PageTest
    {
        protected const string BaseUrl = "https://www.saucedemo.com";

        protected ExpectationHelper _expect = null!;

        [SetUp]
        public async Task BaseSetUpAsync()
        {
            _expect = new ExpectationHelper();

            await Page.GotoAsync(BaseUrl);
        }
    }
}