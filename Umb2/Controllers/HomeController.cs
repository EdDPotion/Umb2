using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace Umb2.Controllers
{
    public class HomeController : SurfaceController
    {

        public ActionResult RenderIntro()
        {
            return PartialView("~/Views/Partials/SiteLayout/_Intro.cshtml");
        }

        public ActionResult RenderFeatured()
        {
            return PartialView("~/Views/Partials/Home/_Featured.cshtml");
        }

        public ActionResult RenderBigList()
        {
            return PartialView("~/Views/Partials/Home/_BigList.cshtml");
        }

        public ActionResult RenderPostList()
        {
            return PartialView("~/Views/Partials/Home/_PostList.cshtml");
        }

        public ActionResult RenderTestimonialList()
        {
            return PartialView("~/Views/Partials/Home/_TestimonialList.cshtml");
        }

    }
}