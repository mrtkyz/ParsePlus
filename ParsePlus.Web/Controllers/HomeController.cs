using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using ParsePlus.Bll.Manager;
using ParsePlus.Web.Views;

namespace ParsePlus.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Upload(HttpPostedFileBase file)
        {
            var result = new XmlViewModel();
            if (file != null && file.ContentLength > 0)
            {
                var fileName = DateTime.Now.ToString("ddMMyyyyhhmmssfff") + Path.GetExtension(file.FileName);
                string path = Path.Combine(Server.MapPath("~/Assert/uploads/"), fileName);
                file.SaveAs(path);

                var manager = new XmlManager();
                result.SourceFilePath = path;
                result.XmlNodes = manager.GetXmlNodes(path);
            }

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
