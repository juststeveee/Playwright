using Microsoft.Playwright;

namespace PlaywrightSpecFlowPOM.Pages;

public class AmazonHomePage
{
    private readonly IPage _user;

    public AmazonHomePage(Hooks.Hooks hooks)
    {
        _user = hooks.User;
    }

    private ILocator SearchInput => _user.Locator("input[id='twotabsearchtextbox']");
    private ILocator SearchButton => _user.Locator("input[id='nav-search-submit-button']");
    private ILocator AcceptCookiesButton => _user.Locator("input[id='sp-cc-accept']");
    private ILocator NavMenu => _user.Locator("#nav-xshop");

    public async Task VerifyHomePage()
    {
        await Assertions.Expect(_user).ToHaveURLAsync("https://www.amazon.co.uk/"); 
        await Assertions.Expect(NavMenu).ToBeVisibleAsync(new() { Timeout = 20000 });
        await Assertions.Expect(SearchInput).ToBeVisibleAsync(new() { Timeout = 20000 });
        await Assertions.Expect(SearchButton).ToBeVisibleAsync();
    }

    public async Task SearchAndEnter(string searchTerm)
    {
        await SearchInput.TypeAsync(searchTerm);
        await SearchButton.ClickAsync();
    }

    public async Task AcceptCookiePreference()
    {
        await AcceptCookiesButton.ClickAsync();
        await Assertions.Expect(AcceptCookiesButton).ToHaveCountAsync(0, new() { Timeout = 60000 });
    }
}