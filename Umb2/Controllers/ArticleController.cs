using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Web.Mvc;
using System.Web.Mvc;
using Umb2.Models;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace Umb2.Controllers
{
    public class ArticleController : SurfaceController
    {

        public ActionResult RenderBodyText()
        {
            return PartialView("~/Views/Partials/Article/_Content.cshtml");
        }
    }
}