using leliao.web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace web.main.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public JsonResult Get(int id)
        {
            return Json(new string[] { "1" }, JsonRequestBehavior.AllowGet);
        }
    }
}
