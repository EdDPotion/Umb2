using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Web.Mvc;
using System.Web.Mvc;


namespace Umb2.Controllers
{
    public class SiteLayoutController : SurfaceController
    {
        public ActionResult RenderHeader()
        {
            return PartialView("~/Views/Partials/SiteLayout/_Header.cshtml");
        }

        public ActionResult RenderFooter()
        {
            return PartialView("~/Views/Partials/SiteLayout/_Footer.cshtml");
        }

        public ActionResult RenderIntro()
        {
            return PartialView("~/Views/Partials/SiteLayout/_Intro.cshtml");
        }
    }
}