using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompanyName.Testing.AcceptanceTests.Framework.Extension
{
    public static class BrowserUtils
    {

        public static async Task SwitchToSession(
            this IBrowserContext BrowserContext,
            int index
            )
        {
            await BrowserContext.Pages[index: 0].BringToFrontAsync();
            Context.CurrentPage.Page = BrowserContext.Pages[index: 0];
        }

        public static async Task CreateNewSession(
            this IBrowserContext BrowserContext,
            IBrowser Browser
            )
        {
            BrowserContext = await Browser.NewContextAsync();
            Context.CurrentPage = new Pages.BasePage(await BrowserContext.NewPageAsync());
        }
    }
}
