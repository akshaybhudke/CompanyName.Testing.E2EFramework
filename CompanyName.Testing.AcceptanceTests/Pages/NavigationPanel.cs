using Microsoft.Playwright;
using System.Threading.Tasks;

namespace CompanyName.Testing.AcceptanceTests.Pages
{
    public class NavigationPanel
    {
        public IPage Page;

        public NavigationPanel(IPage page)
        {
            Page = page;
        }

        private ILocator AccountIcon => Page.Locator("[aria-label='Account']");

        private string LoggedUserNameText =>
            "//a[contains(@class, 'MyAccount_username_name')]";


        public async Task SelectAccountMenuItem(string itemName) 
        {
            await AccountIcon.HoverAsync();

            await Page.ClickAsync(
                $"//a[contains(@class, '_MyAccount_')][contains(text(),'{itemName}')]");        
        }

        public async Task<bool> AccountMenuItemExists(string itemName) 
        {
            await AccountIcon.HoverAsync();

            var elementHandle = await Page.IsVisibleAsync(
                $"//a[contains(@class, '_MyAccount_')][contains(text(),'{itemName}')]");
            return elementHandle;
        }

        public async Task SelectAccountMenuItem()
        {
            await AccountIcon.HoverAsync();

            await Page.ClickAsync(LoggedUserNameText);
        }

        public async Task<string> GetLoggedUserName()
        {
            await AccountIcon.HoverAsync();

            var isPresent = await Page.IsVisibleAsync(LoggedUserNameText);

            return isPresent ? await Page.TextContentAsync(LoggedUserNameText) : null;
                
        }

    }
}