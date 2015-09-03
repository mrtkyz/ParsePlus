using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using ParsePlus.Bll.Manager;
using ParsePlus.Web.Views;
using ParsePlus.Web.Models;

namespace ParsePlus.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new IndexViewModel();
            return View(model);
        }

        [HttpPost]
        public JsonResult Upload(HttpPostedFileBase file, IndexViewModel model)
        {
            var result = new XmlViewModel();
            var downloadedFilePath = string.Empty;

            var fileManager = new FileManager();
            var serverPath = Server.MapPath("~/Assert/uploads/");

            if (!string.IsNullOrEmpty(model.SourceFileUrl))
            {
                downloadedFilePath = fileManager.SaveFileByUrl(serverPath, model.SourceFileUrl);
            }

            if (!string.IsNullOrEmpty(model.TargetFileUrl))
            {
                downloadedFilePath = fileManager.SaveFileByUrl(serverPath, model.TargetFileUrl);
            }

            if (downloadedFilePath == string.Empty && file != null && file.ContentLength > 0)
            {
                MemoryStream target = new MemoryStream();
                file.InputStream.CopyTo(target);
                byte[] data = target.ToArray();

                downloadedFilePath = fileManager.SaveFileByByte(serverPath, data, file.FileName);
            }
            
            var manager = new XmlManager();
            result.SourceFilePath = downloadedFilePath;
            result.XmlNodes = manager.GetXmlNodes(downloadedFilePath);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        
        public JsonResult GetElementValues(string sourceFilePath, string elementName)
        {
            var manager = new XmlManager();
            var values = manager.GetElementValues(sourceFilePath, elementName);

            return Json(values, JsonRequestBehavior.AllowGet);
        }
    }
}
