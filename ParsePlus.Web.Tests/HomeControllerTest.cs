using System.Web.Mvc;
using ParsePlus.Web.Controllers;
using NUnit.Framework;

namespace ParsePlus.Web.Tests
{
    [TestFixture]
    public class HomeControllerTest
    {
        [Test]
        public void Is_Have_IndexPage()
        {
            var cont = new HomeController();
            var page = cont.Index() as ViewResult;

            Assert.IsNotNull(page);
        }
    }
}
