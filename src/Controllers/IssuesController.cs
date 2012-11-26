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
            var list = Session.Query<Issue>()
                .ToList();

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
            if (!Issue.IsValidEmail(email))
                ModelState.AddModelError("email", "please enter a valid email");

            if (string.IsNullOrEmpty(title))
                ModelState.AddModelError("title", "please enter a valid title");

            if (!ModelState.IsValid)
                return View();

            Session.Store(new Issue
            {
                Email = email,
                Title = title,
                Description = description,
                Author = name,
                When = DateTime.Now,
                TypeOfIssue = IssueType.Comment
            });

            ShowMessage(MessageType.Success, "Your issue has been submitted", true);

            //save to db...
            return RedirectToAction("New");
        }

        [HttpGet]
        public ActionResult Detail()
        {
            return View();
        }
    }
}
