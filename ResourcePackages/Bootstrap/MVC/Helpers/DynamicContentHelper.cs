using SitefinityWebApp.ResourcePackages.Bootstrap.MVC.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using Telerik.Sitefinity.DynamicModules;
using Telerik.Sitefinity.DynamicModules.Model;
using Telerik.Sitefinity.GenericContent.Model;
using Telerik.Sitefinity.Lifecycle;
using Telerik.Sitefinity.Model;
using Telerik.Sitefinity.RelatedData;
using Telerik.Sitefinity.Utilities.TypeConverters;

namespace SitefinityWebApp.ResourcePackages.Bootstrap.MVC.Helpers
{
    public class DynamicContentHelper
    {
        private static List<DynamicContent> GetQueryableContent(string type)
        {
            try
            {
                var dynamicModuleManager = DynamicModuleManager.GetManager();
                var objectType = TypeResolutionService.ResolveType(type);

                // Fetch a collection of "live" and "visible" content items.
                var content = dynamicModuleManager.GetDataItems(objectType)
                    .Where(i => i.Status == ContentLifecycleStatus.Live && i.Visible);

                var res = new List<DynamicContent>();

                foreach (var status in content)
                {
                    if (status.GetUIStatus(CultureInfo.CurrentCulture).Equals(ContentUIStatus.Published))
                    {
                        res.Add(status);
                    }
                }
                return res;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static List<Article> GetArticles() {
            var list = new List<Article>();
            var items = GetQueryableContent(Constants.ARTICLE).ToList();
            try
            {
                list.AddRange(items.Select(item => new Article
                {
                    Title = item.GetValue("Title") != null ? item.GetValue("Title").ToString() : string.Empty,
                    Body = item.GetValue("Body") != null ? item.GetValue("Body").ToString() : string.Empty,
                    Date = (DateTime)item.GetValue("Date"),
                    Image = item.GetRelatedItems<Telerik.Sitefinity.Libraries.Model.Image>("Picture").SingleOrDefault() ?? new Telerik.Sitefinity.Libraries.Model.Image()
                }));
            }
            catch (Exception ex)
            {

            }
            return list;
        }
    }
}