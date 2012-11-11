using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IssueTracker.Controllers
{
    public class IssuesController : ApplicationController
    {
        // show a list of issues here
        // GET: /Issues/
        [HttpGet]
        public ActionResult List()
        {


            return View();
        }

    }
}
