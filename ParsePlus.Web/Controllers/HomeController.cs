using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using ParsePlus.Bll.Dto;
using ParsePlus.Bll.Manager;

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
            var result = new List<XmlNodes>();
            if (file != null && file.ContentLength > 0)
            {
                var fileName = DateTime.Now.ToString("ddMMyyyyhhmmssfff") + Path.GetExtension(file.FileName);
                string path = Path.Combine(Server.MapPath("~/Assert/uploads/"), fileName);
                file.SaveAs(path);

                var manager = new XmlManager();
                result = manager.GetXmlNodes(path);
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
