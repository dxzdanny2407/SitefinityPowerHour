﻿using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telerik.Sitefinity.Frontend.Mvc.Infrastructure.Controllers;
using Telerik.Sitefinity.Frontend.Mvc.Infrastructure.Controllers.Attributes;
using Telerik.Sitefinity.Frontend.Navigation.Mvc.Models;
using Telerik.Sitefinity.Frontend.Navigation.Mvc.StringResources;
using Telerik.Sitefinity.Web.UI;

namespace SitefinityWebApp.ResourcePackages.Bootstrap.MVC.Helpers
{
    public class NavigationHelper
    {
        public List<NodeViewModel> GetPages() {
            List<NodeViewModel> nodes = new List<NodeViewModel>();
            this.SelectionMode = PageSelectionMode.TopLevelPages;
            this.LevelsToInclude = 1;
            this.model = this.InitializeModel();
            nodes = model.Nodes.ToList();
            return nodes;
        }
            
        public INavigationModel GetUpdatedModel()
        {
            this.model = this.InitializeModel();
            return this.Model;
        }

        #region Properties

        /// <summary>
        /// Gets or sets the page links to display selection mode.
        /// </summary>
        /// <value>The page display mode.</value>
        public PageSelectionMode SelectionMode
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether [show parent page].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [show parent page]; otherwise, <c>false</c>.
        /// </value>
        public bool ShowParentPage { get; set; }

        /// <summary>
        /// Gets or sets the levels to include.
        /// </summary>
        public virtual int? LevelsToInclude
        {
            get
            {
                return this.levelsToInclude;
            }

            set
            {
                this.levelsToInclude = value;
            }
        }

        /// <summary>
        /// Gets or sets the CSS class that will be applied on the wrapper div of the NavigationWidget (if such is presented).
        /// </summary>
        /// <value>
        /// The CSS class.
        /// </value>
        public string CssClass
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the identifier of the page that is selected if SelectionMode is SelectedPageChildren.
        /// </summary>
        /// <value>The identifier of the page that is selected if SelectionMode is SelectedPageChildren.</value>
        public Guid SelectedPageId { get; set; }

        /// <summary>
        /// Gets or sets a serialized array of the selected pages.
        /// </summary>
        /// <value>
        /// The a serialized array of selected pages.
        /// </value>
        public string SerializedSelectedPages { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether should open external page in new tab.
        /// </summary>
        /// <value>
        /// <c>true</c> if should open external page in new tab; otherwise, <c>false</c>.
        /// </value>
        public bool OpenExternalPageInNewTab { get; set; }

        /// <summary>
        /// Gets the Navigation widget model.
        /// </summary>
        /// <value>
        /// The model.
        /// </value>
        public INavigationModel Model
        {
            get
            {
                if (this.model == null)
                    this.model = this.InitializeModel();

                return this.model;
            }
        }

        #endregion


        #region Private methods

        /// <summary>
        /// Initializes the model.
        /// </summary>
        /// <returns>
        /// The <see cref="INavigationModel"/>.
        /// </returns>
        private INavigationModel InitializeModel()
        {
            var selectedPages = JsonSerializer.DeserializeFromString<SelectedPageModel[]>(this.SerializedSelectedPages);
            var constructorParameters = new Dictionary<string, object>
                         {
                            { "selectionMode", this.SelectionMode },
                            { "selectedPageId", this.SelectedPageId },
                            { "selectedPages", selectedPages },
                            { "levelsToInclude", this.LevelsToInclude },
                            { "showParentPage", this.ShowParentPage },
                            { "cssClass", this.CssClass },
                            { "openExternalPageInNewTab", this.OpenExternalPageInNewTab }
                         };

            return ControllerModelFactory.GetModel<INavigationModel>(this.GetType(), constructorParameters);
        }

        #endregion

        #region Private fields and constants

        private INavigationModel model;
        private int? levelsToInclude = 1;

        #endregion
    }
}