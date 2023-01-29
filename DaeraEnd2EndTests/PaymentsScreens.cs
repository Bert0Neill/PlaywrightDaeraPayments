using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using Microsoft.Playwright;
//using Microsoft.Playwright.MSTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using DaeraEnd2EndTests.Base_Class;

namespace DaeraEnd2EndTests
{
    [TestClass]
    public class PaymentsScreens : PageTest
    {
        static string _testURL = string.Empty;
        private readonly IConfiguration _configuration;

        [AssemblyInitialize()]
        public static void AssemblySetup(TestContext testContext)
        {
            var config = GlobalTestsInitialise.InitConfiguration();
            _testURL = config["PaymentSettings:URL"];

           

        }



        [TestMethod]
        public async Task PerformGoogleSearchAndFind_DotNetCoreTutorials()
        {
            //Given I am on https://www.google.com
            await _Page.GotoAsync("https://www.google.com");

            //When I type dotnetcoretutorials.com into the search box
            await _Page.FillAsync("[title='Search']", "dotnetcoretutorials.com");

            //And I press the button with the text "Google Search"
            await _Page.ClickAsync("[value='Google Search'] >> nth=1");

            //Then the first result is domain dotnetcoretutorials.com
            var firstResult = await _Page.Locator("//cite >> nth=0").InnerTextAsync();
            Assert.AreEqual("https://dotnetcoretutorials.com", firstResult);
        }


        [TestMethod]
        public async Task PaymentSearchHomepageHasPlaywrightInTitleAndGetStartedLinkLinkingtoTheIntroPage()
        {
            await _Page.GotoAsync(_testURL);
            await Expect(_Page.Locator("text=enables reliable end-to-end testing for modern web apps")).ToBeVisibleAsync();

        }

    }
}