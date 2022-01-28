using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompanyName.Testing.AcceptanceTests.Pages
{
    public class MyAccountPage : BasePage
    {
        public MyAccountPage(IPage page) : base(page)
        {
            MyDetailsPage = new MyDetailsPage(page);
        }

        public MyDetailsPage MyDetailsPage { get; }

        public async Task SelectItemInTab(string tabName, string item) {

            var tabSelector = $"a[contains(@class,'tab')][contains(text(), '{tabName}')]";

            await Page.HoverAsync($"//{tabSelector}");
            await Page.ClickAsync($"//li[./{tabSelector}]//a[contains(text(),'{item}')]");
        }
    }
}
