using Microsoft.Extensions.Configuration;

namespace DaeraEnd2EndTests
{
    [TestClass]
    public class PaymentsScreens
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

        public PaymentsScreens()
        {
           
        }

        [TestMethod]
        public async Task PaymentSearchHomepageHasPlaywrightInTitleAndGetStartedLinkLinkingtoTheIntroPage()
        {



            var config = InitConfiguration();
            var clientId = config["PaymentSettings:URL"];


            //await Page.GotoAsync("https://playwright.dev");

            //// Expect a title "to contain" a substring.
            //await Expect(Page).ToHaveTitleAsync(new Regex("Playwright"));

            //// create a locator
            //var getStarted = Page.GetByRole(AriaRole.Link, new() { Name = "Get started" });

            //// Expect an attribute "to be strictly equal" to the value.
            //await Expect(getStarted).ToHaveAttributeAsync("href", "/docs/intro");

            //// Click the get started link.
            //await getStarted.ClickAsync();

            //// Expects the URL to contain intro.
            //await Expect(Page).ToHaveURLAsync(new Regex(".*intro"));
        }


    }
}