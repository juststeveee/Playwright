using Microsoft.Playwright;

namespace PlaywrightSpecFlowPOM.Pages;

public class SearchResultsPage
{
    private readonly IPage _user;

    public SearchResultsPage(Hooks.Hooks hooks)
    {
        _user = hooks.User;
    }
    
    private ILocator searchResults => _user.Locator("[@id='search']/div[1]/div[1]/div");
    
    public async Task VerifySearchResults(
        string bookTitle, 
        string author)
    {
        searchResults.Locator($"text={bookTitle}");
        searchResults.Locator($"text={author}");

    }
}