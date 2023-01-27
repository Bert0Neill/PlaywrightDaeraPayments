using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.MSTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;


namespace DaeraEnd2EndTests
{
    [TestClass]
    public class PaymentsScreens : PageTest
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

        [TestMethod]
        public async Task ShouldOpenPlaywright()
        {
            //Given I am on https://www.google.com
            await Page.GotoAsync("https://www.google.com");

            //When I type dotnetcoretutorials.com into the search box
            await Page.FillAsync("[title='Search']", "dotnetcoretutorials.com");

            //And I press the button with the text "Google Search"
            await Page.ClickAsync("[value='Google Search'] >> nth=1");

            //Then the first result is domain dotnetcoretutorials.com
            var firstResult = await Page.Locator("//cite >> nth=0").InnerTextAsync();
            Assert.AreEqual("https://dotnetcoretutorials.com", firstResult);
        }


    [TestMethod]
        [Ignore]
        public async Task PaymentSearchHomepageHasPlaywrightInTitleAndGetStartedLinkLinkingtoTheIntroPage()
        {
            var config = InitConfiguration();
            var clientId = config["PaymentSettings:URL"];

            await Page.GotoAsync("https://playwright.dev");
            await Expect(Page.Locator("text=enables reliable end-to-end testing for modern web apps")).ToBeVisibleAsync();

        }


    }
}