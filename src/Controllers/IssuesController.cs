using IssueTracker.Models;
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
            var list = new List<Issues>();
            list.Add(new Issues
            {
                Description = "",
                When = DateTime.Now,
                Title = "Something Happened",
                TypeOfIssue = IssueType.Bug
            });
            list.Add(new Issues
            {
                Description = "",
                When = DateTime.Now,
                Title = "Logo get",
                TypeOfIssue = IssueType.Comment
            }); list.Add(new Issues
            {
                Description = "",
                When = DateTime.Now,
                Title = "show some list",
                TypeOfIssue = IssueType.TODO
            }); list.Add(new Issues
            {
                Description = "",
                When = DateTime.Now,
                Title = "take a break, have a kit kat",
                TypeOfIssue = IssueType.Archive
            });
            return View(list);
        }

        [HttpGet]
        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult New(string title, string description, string name, string email)
        {
            //save to db...
            return View();
        }

        [HttpGet]
        public ActionResult Detail()
        {
            return View();
        }
    }
}
