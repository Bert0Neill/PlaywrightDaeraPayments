using Microsoft.Playwright.MSTest;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DaeraEnd2EndTests.Base_Class
{
    [TestClass]
    public class PageTest : ContextTest
    {
        public IPage? Page { get; private set; }
        [TestInitialize]
        public async Task PageSetup()
        {
            Page = await Context!.NewPageAsync().ConfigureAwait(false);
        }
    }
}
