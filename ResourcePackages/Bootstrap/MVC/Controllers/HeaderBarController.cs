using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Sitefinity.Mvc;

namespace SitefinityWebApp.ResourcePackages.Bootstrap.MVC.Controllers
{
    [ControllerToolboxItem(Name = "HeaderBar", Title = "Header Bar", SectionName = "Template Widgets")]
    public class HeaderBarController : Controller
    {
        // GET: HeaderBar
        public ActionResult Index()
        {
            return View("~/ResourcePackages/Bootstrap/MVC/Views/HeaderBar/HeaderBar.cshtml");
        }
    }
}