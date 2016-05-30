using NUnit.Framework;
using ParsePlus.Bll.Manager;

namespace ParsePlus.Web.Tests
{
    [TestFixture]
    public class FileManagerTest
    {
        [Test]
        public void File_Must_Extesion_Xml()
        {
            FileManager fileManager = new FileManager();

            var extension = fileManager.ControlExtension("filename.xml");

            Assert.AreEqual(extension, true);
        }

        [Test]
        public void File_Must_Extesion_Excel()
        {
            FileManager fileManager = new FileManager();

            var extension = fileManager.ControlExtension("filename.xls");

            Assert.AreEqual(extension, true);
        }
    }
}
