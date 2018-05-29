using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ScrumItTests.IntegrationTests
{
    public class IntegrationTestAttribute : TestCategoryBaseAttribute
    {
        public override IList<string> TestCategories
        {
            get { return new List<string> { "IntegrationTest" }; }
        }
    }
}