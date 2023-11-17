using PlaywrightSpecFlowPOM.Pages;

namespace PlaywrightSpecFlowPOM.Steps;

[Binding]
public class SearchResultSteps
{
    private readonly SearchResultsPage _searchResultsPage;

    public SearchResultSteps(SearchResultsPage searchResultsPage)
    {
        _searchResultsPage = searchResultsPage;
    }

    [Then(@"the search results show the book how they broke britain as the first result")]
    public async Task ThenTheSearchResultsShowTheBookHowTheyBrokeBritainAsTheFirstResult()
    {
        await _searchResultsPage.VerifySearchResults(
            "How They Broke Britain",
            "by James O'Brien and Penguin Audio");
    }
}