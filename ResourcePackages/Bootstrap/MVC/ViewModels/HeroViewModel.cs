using SitefinityWebApp.ResourcePackages.Bootstrap.MVC.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitefinityWebApp.ResourcePackages.Bootstrap.MVC.ViewModels
{
    public class HeroViewModel
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string ImageUrl { get; set; }

        public HeroViewModel(string imageProvider, Guid imageId) {
            this.ImageUrl = ImageHelper.GetImageUrl(imageProvider, imageId);
        }
    }
}