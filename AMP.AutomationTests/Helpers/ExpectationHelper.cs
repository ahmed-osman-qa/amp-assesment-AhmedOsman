using static Microsoft.Playwright.Assertions;

namespace AMP.AutomationTests.Helpers
{
    public class ExpectationHelper
    {
        public async Task IsVisibleAsync(ILocator locator)
        {
            await Expect(locator).ToBeVisibleAsync();
        }

        public async Task HasTextAsync(
            ILocator locator,
            string expectedText)
        {
            await Expect(locator).ToHaveTextAsync(expectedText);
        }

        public async Task ContainsTextAsync(
            ILocator locator,
            string expectedText)
        {
            await Expect(locator).ToContainTextAsync(expectedText);
        }

        public async Task HasUrlAsync(
            IPage page,
            string expectedUrl)
        {
            await Expect(page).ToHaveURLAsync(expectedUrl);
        }
    }
}