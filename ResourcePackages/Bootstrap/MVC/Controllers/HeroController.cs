using SitefinityWebApp.ResourcePackages.Bootstrap.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Sitefinity.Mvc;

namespace SitefinityWebApp.ResourcePackages.Bootstrap.MVC.Controllers
{
    [ControllerToolboxItem(Name = "Hero", Title = "Hero", SectionName = "Power Hour Widgets")]
    public class HeroController : Controller
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public Guid Image { get; set; }
        public string ImageProviderName { get; set; }

        // GET: Hero
        public ActionResult Index()
        {
            HeroViewModel model = new HeroViewModel(ImageProviderName, Image)
            {
                Title = Title,
                Body= Body
            };
            return View("~/ResourcePackages/Bootstrap/MVC/Views/Hero/Hero.cshtml", model);
        }
    }
}