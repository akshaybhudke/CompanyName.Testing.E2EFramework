using CompanyName.Testing.AcceptanceTests.Framework;
using CompanyName.Testing.AcceptanceTests.Framework.Navigation;
using CompanyName.Testing.AcceptanceTests.Pages;
using System;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace CompanyName.Testing.AcceptanceTests.Steps
{
    [Binding]
    public class LoginSteps
    {
        private readonly Configuration config;
        private LoginPage loginPage;


        public LoginSteps(Configuration config) 
        {
            this.config = config;
        }

        [Given(@"I navigate to landing page")]
        public async Task GivenINavigateToLandingPage()
        {
            await NavigationHelper.NavigateTo<LandingPage>();
        }

        [When(@"I entered valid username as '(.*)'")]
        public async Task WhenIEnteredValidUsername(string username)
        {
            var userData = config.UserData.FirstOrDefault(u => u.UserName == username);
            loginPage = await NavigationHelper.NavigateTo<LoginPage>();
            await loginPage.SubmitUserLoginDetails(userData);

        }

        [When(@"I entered valid password")]
        public void WhenIEnteredValidPassword()
        {
           
        }

        [Then(@"I should see welcome page")]
        public void ThenIShouldSeeWelcomePage()
        {
           
        }

    }
}
