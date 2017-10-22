using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectOffice.Controllers
{
    public class SiteLayoutController : Controller
    {
        // GET: SiteLayout
        public ActionResult RenderHeader()
        {
            return PartialView("~/Views/Shared/_Header.cshtml");
        }

        public ActionResult RenderFooter()
        {
            return PartialView("~/Views/Shared/_Footer.cshtml");
        }
    }
}