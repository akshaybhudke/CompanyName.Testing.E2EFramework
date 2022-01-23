using CompanyName.Testing.AcceptanceTests.Framework;
using Microsoft.Playwright;
using System.Threading.Tasks;

namespace CompanyName.Testing.AcceptanceTests.Pages
{
    public class LoginPage  : BasePage
    { 
        public LoginPage(IPage page) :base(page)
        {
        }

        private ILocator UserLoginTextField => Page.Locator("#user_email_login");

        private ILocator UserPasswordTextField => Page.Locator("#user_password");

        private ILocator LoginButton => Page.Locator("#user_submit");

        public async Task SubmitUserLoginDetails(UserData userData) {

            await UserLoginTextField.FillAsync(userData.Login);
            await UserPasswordTextField.FillAsync(userData.Password);
            await LoginButton.ClickAsync();
            Context.CurrentUser = userData.UserName;
           
        }
    }
}