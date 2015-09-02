using System.IO;

namespace ParsePlus.Bll.Manager
{
    public class FileManager
    {
        public bool ControlExtension(string fileName)
        {
            var ext = Path.GetExtension(fileName);

            return (ext == ".xls" || ext == ".xml");
        }
    }
}