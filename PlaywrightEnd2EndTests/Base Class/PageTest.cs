using Microsoft.Playwright.MSTest;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PlaywrightEnd2EndTests.Base_Class
{
    /// <summary>
    /// The ContextTest setting are overriden by the .runsettings file in your project
    /// </summary>
    [TestClass]
    
    public class PageTest : ContextTest
    {
        public IPage? _Page { get; private set; }

        [TestInitialize]
        public async Task PageSetup()
        {
            _Page = await Context!.NewPageAsync().ConfigureAwait(false);
        }
    }
}
