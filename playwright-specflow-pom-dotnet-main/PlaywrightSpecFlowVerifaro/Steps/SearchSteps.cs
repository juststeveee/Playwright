using Microsoft.Playwright;
using PlaywrightSpecFlowPOM.Pages;

namespace PlaywrightSpecFlowPOM.Steps;

[Binding]
public class SearchSteps
{
    private readonly IPage _user;
    private readonly AmazonHomePage _amazonHomePage;

    public SearchSteps(Hooks.Hooks hooks, AmazonHomePage amazonHomePage)
    {
        _user = hooks.User;
        _amazonHomePage = amazonHomePage;
    }
    
    [Given(@"the user is on the amazon homepage")]
    public async Task GivenTheUserIsOnTheAmazonHomepage()
    { 
        // Go to Amazon homepage
        await _user.GotoAsync("https://www.amazon.co.uk/");
        await _user.ScreenshotAsync(new() { Path = "screenshot.png" });
        
        // Accept Cookies
        await _amazonHomePage.AcceptCookiePreference();
        
        // Verify homepage
        await _amazonHomePage.VerifyHomePage();
        
    }

    [When(@"the user searches for '(.*)'")]
    public async Task WhenTheUserSearchesFor(string searchTerm)
    {
        // Type the search term and press enter
        await _amazonHomePage.SearchAndEnter(searchTerm);
    }
}