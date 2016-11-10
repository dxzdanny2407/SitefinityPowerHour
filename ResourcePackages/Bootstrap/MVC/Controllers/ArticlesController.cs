using SitefinityWebApp.ResourcePackages.Bootstrap.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Sitefinity.Mvc;

namespace SitefinityWebApp.ResourcePackages.Bootstrap.MVC.Controllers
{
    [ControllerToolboxItem(Name = "ArticleList", Title = "Article List", SectionName = "Power Hour Widgets")]
    public class ArticlesController : Controller
    {
        // GET: ArticlesList
        public ActionResult Index()
        {
            ArticlesViewModel model = new ArticlesViewModel();
            return View("~/ResourcePackages/Bootstrap/MVC/Views/Articles/ArticleList.cshtml", model);
        }

        public ActionResult Detail() {
            return View("~/ResourcePackages/Bootstrap/MVC/Views/Articles/ArticleDetail.cshtml");
        }
    }
}