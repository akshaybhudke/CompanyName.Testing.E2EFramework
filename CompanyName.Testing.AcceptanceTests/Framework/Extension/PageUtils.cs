using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompanyName.Testing.AcceptanceTests.Framework.Extension
{
    public static class PageUtils
    {
        public static async Task FillInputForLabel(
            this IPage page, 
            string labelText,
            string textToWrite) 
        {

            var inputId = await page.GetAttributeAsync(
                $"//label[contains(text(),'{labelText}')]",
                "for");

            await page.FillAsync($"input#{inputId}", textToWrite);
        }
    }
}
