using CompanyName.Testing.AcceptanceTests.Hooks.Basics;
using CompanyName.Testing.AcceptanceTests.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyName.Testing.AcceptanceTests.Framework.Navigation
{
    public static class NavigationHelper
    {
        private static Dictionary<Type, Func<BasePage, Task>> NavigateToActions = new Dictionary<Type, Func<BasePage, Task>>();

        public static void AddNavigationData(Dictionary<Type, Func<BasePage, Task>> data)
        {
            NavigateToActions = NavigateToActions.Concat(data).ToDictionary(x => x.Key, x => x.Value);

        }

        public static async Task<T> NavigateTo<T>() where T : BasePage
        {
            var requiredPageType = typeof(T);

            var currentPage = Context.CurrentPage ?? new BasePage(Driver.BrowserContext.Pages.First());


            if (!NavigateToActions.TryGetValue(requiredPageType, out var navigateToAction)) 
            {
                throw new Exception(

                    $"Page '{requiredPageType.Name}' is not mapped in NavigationHelper");
            }

            await navigateToAction(currentPage);
            var newPage = (T)Activator.CreateInstance(typeof(T), currentPage.Page);
            Context.CurrentPage = newPage;

            return newPage;
        }
    }
}
