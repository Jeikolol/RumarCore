using Humanizer;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace RumarApp.Helpers
{
    public static class HMTLHelperExtensions
    {
        public static string IsSelected(this IHtmlHelper html, string controller = null, string action = null,
            string cssClass = null)
        {

            if (String.IsNullOrEmpty(cssClass))
                cssClass = "active";

            string currentAction = (string)html.ViewContext.RouteData.Values["action"];
            string currentController = (string)html.ViewContext.RouteData.Values["controller"];

            if (String.IsNullOrEmpty(controller))
                controller = currentController;

            if (String.IsNullOrEmpty(action))
                action = currentAction;

            return controller == currentController && action == currentAction ? cssClass : String.Empty;
        }

        public static string HumanizerDateTime(this DateTime date)
        {
            return date.Humanize(false, culture: CultureInfo.CreateSpecificCulture("es-DO"));
        }

    }
}
