using CompanyName.Testing.AcceptanceTests.Framework.Extension;
using Microsoft.Playwright;
using System.Threading.Tasks;

namespace CompanyName.Testing.AcceptanceTests.Pages
{
    public class MyDetailsPage
    {
        private IPage Page;

        public MyDetailsPage(IPage page)
        {
            Page = page;
        }

        private ILocator ChangePasswordSaveButton =>
            Page.Locator("form[action*='ChangePassword'] > input.save");

        public async Task ChangePassword(string oldPass , string newPass) 
        {

            await Page.FillInputForLabel("My Old Password is", oldPass);
            await Page.FillInputForLabel("My new Password is", newPass);
            await Page.FillInputForLabel("Confirm password", newPass);
            await ChangePasswordSaveButton.ClickAsync();
        }

    }
}