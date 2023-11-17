using Microsoft.Playwright;

namespace PlaywrightSpecFlowPOM.Hooks
{
    [Binding]
    public class Hooks
    {
        public IPage User { get; private set; } = null!;

        [BeforeScenario] 
        public async Task RegisterSingleInstancePractitioner()
        {
            var browserType = Environment.GetEnvironmentVariable("BROWSER_TYPE") ?? "chromium";
            Console.WriteLine($"Browser -> {browserType}");
            var playwright = await Playwright.CreateAsync();
            var browserTypeLaunchOptions = new BrowserTypeLaunchOptions { Headless = false };
            
            IBrowser browser = browserType.ToLower() switch
            {
                "firefox" => await playwright.Firefox.LaunchAsync(browserTypeLaunchOptions),
                "webkit" => await playwright.Webkit.LaunchAsync(browserTypeLaunchOptions),
                _ => await playwright.Chromium.LaunchAsync(browserTypeLaunchOptions)
            };
            var context1 = await browser.NewContextAsync(new BrowserNewContextOptions{IgnoreHTTPSErrors = true});
            User = await context1.NewPageAsync();
        }
    }
}