using DaeraEnd2EndTests.Base_Class;
using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;
using Microsoft.Playwright.MSTest;
using System.Text.RegularExpressions;


namespace DaeraEnd2EndTests
{
    [TestClass]
    public class PaymentsScreens : PageStartUp
    {
        private readonly IConfiguration _configuration;
        //private Microsoft.Playwright.IPage page;

        //[TestInitialize]
        //public async Task PageSetup()
        //{
        //    using var playwright = await Playwright.CreateAsync();
        //    await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        //    {
        //        Headless = false,
        //    });
        //    var context = await browser.NewContextAsync();
        //    page = await context.NewPageAsync();

        //    //page = await Context!.NewPageAsync().ConfigureAwait(false);
        //}

        //[TestCleanup]
        //public async void TestCleanup()
        //{

        //}

        public static IConfiguration InitConfiguration()
        {
            var environment = Environment.GetEnvironmentVariable("Development");
            var config = new ConfigurationBuilder()
                //.AddJsonFile("appsettings.json")
                //.AddJsonFile($"appsettings.{environment}.json")
                .AddJsonFile($"appsettings.dev.json")
                .Build();
            return config;
        }

        [TestMethod]
        public async Task ShouldOpenPlaywright()
        {
            //Given I am on https://www.google.com
            await page.GotoAsync("https://www.google.com");

            //When I type dotnetcoretutorials.com into the search box
            await page.FillAsync("[title='Search']", "dotnetcoretutorials.com");

            //And I press the button with the text "Google Search"
            await page.ClickAsync("[value='Google Search'] >> nth=1");

            //Then the first result is domain dotnetcoretutorials.com
            var firstResult = await page.Locator("//cite >> nth=0").InnerTextAsync();
            Assert.AreEqual("https://dotnetcoretutorials.com", firstResult);
        }


        [TestMethod]
        public async Task PaymentSearchHomepageHasPlaywrightInTitleAndGetStartedLinkLinkingtoTheIntroPage()
        {
            var config = InitConfiguration();
            var clientId = config["PaymentSettings:URL"];

            await page.GotoAsync("https://playwright.dev");
            await Assertions.Expect(page.Locator("text=enables reliable end-to-end testing for modern web apps")).ToBeVisibleAsync();

        }

        [TestMethod]
        public async Task HomepageHasPlaywrightInTitleAndGetStartedLinkLinkingtoTheIntroPage()
        {
            var path = Path.GetFullPath("index.html");
            Assert.IsNotNull(page);
            await page.GotoAsync("file://" + path);
            var h1 = await page.TextContentAsync("h1");
            Assert.AreEqual("Getting started.", h1);
            var title = await page.EvaluateAsync("() => document.title");
            Assert.AreEqual("This is a website.", title);
            await Assertions.Expect(page.Locator("h1")).ToBeVisibleAsync();
        }

        [TestMethod]    
        public async Task GoogleSearch()
        {
            //using var playwright = await Playwright.CreateAsync();
            //await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            //{
            //    Headless = false,
            //});
            //var context = await browser.NewContextAsync();
            //var page = await context.NewPageAsync();

            await page.GotoAsync("https://www.google.com/");

            await page.GetByRole(AriaRole.Combobox, new() { Name = "Search" }).ClickAsync();

            await page.GetByRole(AriaRole.Combobox, new() { Name = "Search" }).FillAsync("Michael Schenker");

            await page.GetByRole(AriaRole.Combobox, new() { Name = "Search" }).PressAsync("Enter");

            await page.CloseAsync();

        }

    }
}