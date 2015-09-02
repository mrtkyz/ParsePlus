using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParsePlus.Bll.Manager;

namespace ParsePlus.Web.Tests
{
    [TestClass]
    public class FileManagerTest
    {
        [TestMethod]
        public void File_Must_Extesion_Xml()
        {
            FileManager fileManager = new FileManager();

            var extension = fileManager.ControlExtension("filename.xml");

            Assert.AreEqual(extension, true);
        }

        [TestMethod]
        public void File_Must_Extesion_Excel()
        {
            FileManager fileManager = new FileManager();

            var extension = fileManager.ControlExtension("filename.xls");

            Assert.AreEqual(extension, true);
        }
    }
}
