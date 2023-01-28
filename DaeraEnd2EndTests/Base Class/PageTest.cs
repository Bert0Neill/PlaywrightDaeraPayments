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
    public class PageStartUp : ContextTest
    {
        public IPage? page { get; private set; }

        [TestInitialize]
        public async Task PageSetup()
        {
            page = await Context!.NewPageAsync().ConfigureAwait(false);            

            
        }
    }
}
