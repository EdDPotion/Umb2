﻿using System;
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
    public class SiteLayoutController : SurfaceController
    {
        
        public ActionResult RenderFooter()
        {
            return PartialView("~/Views/Partials/SiteLayout/_Footer.cshtml");
        }

        /// <summary>
        /// Renders the top navigation in the header partial
        /// </summary>
        /// <returns>Partial view with a model</returns>
        /// 
        public ActionResult RenderHeader()
        {
            List<NavigationListItem> nav = GetNavigationModelFromDatabase();
            return PartialView("~/Views/Partials/SiteLayout/_Header.cshtml", nav);
        }



        /// <summary>
        /// Finds the home page and gets the navigation structure based on it and it's children
        /// </summary>
        /// <returns>A List of NavigationListItems, representing the structure of the site.</returns>
        private List<NavigationListItem> GetNavigationModelFromDatabase()
        {
            IPublishedContent homePage = CurrentPage.AncestorOrSelf(1).DescendantsOrSelf().Where(x => x.DocumentTypeAlias == "home").FirstOrDefault();
            List<NavigationListItem> nav = new List<NavigationListItem>();
            nav.Add(new NavigationListItem(new NavigationLink(homePage.Url, homePage.Name)));
            nav.AddRange(GetChildNavigationList(homePage));
            return nav;
        }

        /// <summary>
        /// Loops through the child pages of a given page and their children to get the structure of the site.
        /// </summary>
        /// <param name="page">The parent page which you want the child structure for</param>
        /// <returns>A List of NavigationListItems, representing the structure of the pages below a page.</returns>
        private List<NavigationListItem> GetChildNavigationList(IPublishedContent page)
        {
            List<NavigationListItem> listItems = null;
            var childPages = page.Children.Where("Visible").Where(x => !x.HasValue("hideInNav") || (x.HasValue("hideInNav")) && !x.GetPropertyValue<bool>("hideInNav"));
            if (childPages != null && childPages.Any() && childPages.Count() > 0)
            {
                listItems = new List<NavigationListItem>();
                foreach (var childPage in childPages)
                {
                    NavigationListItem listItem = new NavigationListItem(new NavigationLink(childPage.Url, childPage.Name));
                    listItem.Items = GetChildNavigationList(childPage);
                    listItems.Add(listItem);
                }
            }
            return listItems;
        }
    }
}