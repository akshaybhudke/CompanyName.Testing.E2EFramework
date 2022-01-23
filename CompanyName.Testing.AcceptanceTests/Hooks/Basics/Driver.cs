using CompanyName.Testing.AcceptanceTests.Framework;
using CompanyName.Testing.AcceptanceTests.Pages;
using Microsoft.Playwright;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace CompanyName.Testing.AcceptanceTests.Hooks.Basics
{
    [Binding]
    public static class Driver
    {
        public static IBrowserContext BrowserContext;
        public static IPlaywright PlayWright;
        public static IBrowser Browser;

        [BeforeTestRun(Order = 5)]
        public static async Task TestRunSetUp() 
        {
            PlayWright = await Microsoft.Playwright.Playwright.CreateAsync();

            var isCI = bool.TryParse(
                Environment.GetEnvironmentVariable("USE_CI_BROWSER_OPTIONS"),
                out _);

            var browserOptions = isCI
                ? JsonConvert.DeserializeObject<BrowserTypeLaunchOptions>(
                    await File.ReadAllTextAsync(
                        $"{Environment.CurrentDirectory}\\browseroptions.json"))
                : new BrowserTypeLaunchOptions { Headless = false };

            Browser = await PlayWright.Chromium.LaunchAsync(browserOptions);

            BrowserContext = await Browser.NewContextAsync();

        }

        [BeforeScenario]
        public static async Task ScenarioSetUp() 
        {
            Context.CurrentPage = new BasePage(await BrowserContext.NewPageAsync());
        }


        [AfterTestRun]
        public static async Task BasicCleanup()
        {
            await Browser.CloseAsync();
            PlayWright.Dispose();
        }
    }
}
