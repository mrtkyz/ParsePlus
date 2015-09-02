using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParsePlus.Web.Controllers;

namespace ParsePlus.Web.Tests
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Is_Have_IndexPage()
        {
            var cont = new HomeController();
            var page = cont.Index() as ViewResult;

            Assert.IsNotNull(page);
        }
    }
}
