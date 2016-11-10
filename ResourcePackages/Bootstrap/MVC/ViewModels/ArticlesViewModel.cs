using SitefinityWebApp.ResourcePackages.Bootstrap.MVC.Helpers;
using SitefinityWebApp.ResourcePackages.Bootstrap.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitefinityWebApp.ResourcePackages.Bootstrap.MVC.ViewModels
{
    public class ArticlesViewModel
    {
        public List<Article> Articles { get; set; }

        public ArticlesViewModel() {
            this.Articles = DynamicContentHelper.GetArticles();
        }
    }
}