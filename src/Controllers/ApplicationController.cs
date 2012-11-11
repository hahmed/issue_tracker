using Raven.Client;
using Raven.Client.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IssueTracker.Controllers
{
    public abstract class ApplicationController : Controller
    {
        private static readonly Lazy<IDocumentStore> lazyDocStore =
            new Lazy<IDocumentStore>(() =>
            {
                var docStore = new DocumentStore
                {
                    Url = "http://localhost:8040",
                    DefaultDatabase = "IssueTracker"
                };
                docStore.Initialize();

                //IndexCreation.CreateIndexes(typeof(Posts_Search).Assembly, docStore);

                return docStore;
            });

        public static IDocumentStore DocumentStore
        {
            get { return lazyDocStore.Value; }
        }

        public new IDocumentSession Session { get; set; }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Session = DocumentStore.OpenSession();
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            using (Session)
            {
                if (Session == null)
                    return;

                if (filterContext.Exception != null)
                    return;

                Session.SaveChanges();
            }
        }

        protected override JsonResult Json(object data, string contentType, System.Text.Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            return base.Json(data, contentType, contentEncoding, JsonRequestBehavior.AllowGet);
        }
    }
}
