using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IssueTracker.Helpers
{
    public static class HtmlHelperExtensions
    {
        /// <summary>
        /// Render all messages that have been set during execution of the controller action.
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <returns></returns>
        public static HtmlString RenderMessages(this HtmlHelper htmlHelper)
        {
            var messages = String.Empty;
            foreach (var messageType in Enum.GetNames(typeof(IssueTracker.Controllers.ApplicationController.MessageType)))
            {
                var message = htmlHelper.ViewContext.ViewData.ContainsKey(messageType)
                                ? htmlHelper.ViewContext.ViewData[messageType]
                                : htmlHelper.ViewContext.TempData.ContainsKey(messageType)
                                    ? htmlHelper.ViewContext.TempData[messageType]
                                    : null;
                if (message != null)
                {
                    var messageBoxBuilder = new TagBuilder("div");
                    messageBoxBuilder.AddCssClass(String.Format("alert alert-block alert-{0}", messageType.ToLowerInvariant()));

                    var dismiss = new TagBuilder("button");
                    dismiss.MergeAttribute("type", "button");
                    dismiss.MergeAttribute("class", "close");
                    dismiss.MergeAttribute("data_dismiss", "alert");
                    dismiss.SetInnerText("x");

                    messageBoxBuilder.InnerHtml = dismiss.ToString();

                    var content = new TagBuilder("p");
                    content.SetInnerText("Success: " + message.ToString());

                    messageBoxBuilder.InnerHtml += content.ToString();
                    messages += messageBoxBuilder.ToString();
                }
            }
            return MvcHtmlString.Create(messages);
        }
    }
}