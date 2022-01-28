using CompanyName.Testing.AcceptanceTests.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompanyName.Testing.AcceptanceTests.Framework.Navigation
{
    public static class NavigationMapping
    {
        public static readonly Dictionary<Type, Func<BasePage, Task>> NavigateToActions =
            new Dictionary<Type, Func<BasePage, Task>>()
            {

                {
                    typeof(LandingPage),
                    p => p.Page.GotoAsync(Configuration.Get().BaseUrl)
                },

                {
                    typeof(LoginPage),
                    p => p.Navigation.SelectAccountMenuItem("Sign In")
                },

                {
                    typeof(MyAccountPage),
                    p => p.Navigation.SelectAccountMenuItem()

                }
            };
    }
}
