using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitefinityWebApp.ResourcePackages.Bootstrap.MVC.Models
{
    public class Article
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime Date { get; set; }
        public Telerik.Sitefinity.Libraries.Model.Image Image { get; set; }
    }
}