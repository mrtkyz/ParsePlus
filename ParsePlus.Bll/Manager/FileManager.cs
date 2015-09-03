using System;
using System.IO;
using System.Net;

namespace ParsePlus.Bll.Manager
{
    public class FileManager
    {
        public bool ControlExtension(string fileName)
        {
            var ext = Path.GetExtension(fileName);

            return (ext == ".xls" || ext == ".xml");
        }

        public string SaveFileByUrl(string serverPath, string url)
        {
            using (WebClient client = new WebClient())
            {
                var fileName = DateTime.Now.ToString("ddMMyyyyhhmmssfff") + Path.GetExtension(url);
                string path = Path.Combine(serverPath, fileName);

                client.DownloadFile(url, path);

                return path;
            }
        }

        public string SaveFileByByte(string serverPath, byte[] data, string originalFileName)
        {
            var fileName = DateTime.Now.ToString("ddMMyyyyhhmmssfff") + Path.GetExtension(originalFileName);
            string path = Path.Combine(serverPath, fileName);
            
            File.WriteAllBytes(path, data);

            return path;
        }
    }
}