using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;
using System.Text.RegularExpressions;

namespace DaeraEnd2EndTests
{
    [TestClass]
    public class PaymentsScreens //: PageTest
    {
        private readonly IConfiguration _configuration;

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

        //[TestMethod]
        //public async Task ShouldOpenPlaywright()
        //{
        //    //Given I am on https://www.google.com
        //    await Page.GotoAsync("https://www.google.com");

        //    //When I type dotnetcoretutorials.com into the search box
        //    await Page.FillAsync("[title='Search']", "dotnetcoretutorials.com");

        //    //And I press the button with the text "Google Search"
        //    await Page.ClickAsync("[value='Google Search'] >> nth=1");

        //    //Then the first result is domain dotnetcoretutorials.com
        //    var firstResult = await Page.Locator("//cite >> nth=0").InnerTextAsync();
        //    Assert.AreEqual("https://dotnetcoretutorials.com", firstResult);
        //}


    //[TestMethod]
    //    [Ignore]
    //    public async Task PaymentSearchHomepageHasPlaywrightInTitleAndGetStartedLinkLinkingtoTheIntroPage()
    //    {
    //        var config = InitConfiguration();
    //        var clientId = config["PaymentSettings:URL"];

    //        await Page.GotoAsync("https://playwright.dev");
    //        await Expect(Page.Locator("text=enables reliable end-to-end testing for modern web apps")).ToBeVisibleAsync();

    //    }

        //[TestMethod]
        //public async Task HomepageHasPlaywrightInTitleAndGetStartedLinkLinkingtoTheIntroPage()
        //{
        //    await Page.GotoAsync("https://playwright.dev");

        //    // Expect a title "to contain" a substring.
        //    await Expect(Page).ToHaveTitleAsync(new Regex("Playwright"));

        //    // create a locator
        //    var getStarted = Page.GetByRole(AriaRole.Link, new() { Name = "Get started" });

        //    // Expect an attribute "to be strictly equal" to the value.
        //    await Expect(getStarted).ToHaveAttributeAsync("href", "/docs/intro");

        //    // Click the get started link.
        //    await getStarted.ClickAsync();

        //    // Expects the URL to contain intro.
        //    await Expect(Page).ToHaveURLAsync(new Regex(".*intro"));
        //}

        [TestMethod]    
        public async Task GoogleSearch()
        {
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
            });
            var context = await browser.NewContextAsync();
            var page = await context.NewPageAsync();

            await page.GotoAsync("https://www.google.com/");

            await page.GetByRole(AriaRole.Combobox, new() { Name = "Search" }).ClickAsync();

            await page.GetByRole(AriaRole.Combobox, new() { Name = "Search" }).FillAsync("Michael Schenker");

            await page.GetByRole(AriaRole.Combobox, new() { Name = "Search" }).PressAsync("Enter");

            await page.CloseAsync();

        }

    }
}