using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IsItUpWeb.Controllers
{
    public class UpCheckerController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}