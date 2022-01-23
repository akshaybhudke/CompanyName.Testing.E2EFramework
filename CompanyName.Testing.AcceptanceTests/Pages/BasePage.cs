using Microsoft.Playwright;

namespace CompanyName.Testing.AcceptanceTests.Pages
{
    public class BasePage
    {
        public BasePage(IPage page)
        {
            Page = page;
            Navigation = new NavigationPanel(page);
        }

        public NavigationPanel Navigation { get; }
        public IPage Page { get; set; }
        
    }
}