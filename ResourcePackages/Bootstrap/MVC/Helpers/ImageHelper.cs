using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telerik.Sitefinity.Modules.Libraries;

namespace SitefinityWebApp.ResourcePackages.Bootstrap.MVC.Helpers
{
    public class ImageHelper
    {
        public static string GetImageUrl(string imageProviderName, Guid imageId) {
            var image = GetImage(imageProviderName, imageId);
            if (image != null)
            {
                return image.Url;
            }
            else {
                return string.Empty;
            }
            
        }
        public static Telerik.Sitefinity.Libraries.Model.Image GetImage(string imageProviderName, Guid imageId)
        {
            LibrariesManager librariesManager = LibrariesManager.GetManager(imageProviderName);
            return librariesManager.GetImages().Where(i => i.Id == imageId).FirstOrDefault();
        }
    }
}