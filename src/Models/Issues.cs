using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IssueTracker.Models
{
    public class Issues
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime When { get; set; }

        public IssueType TypeOfIssue { get; set; }
    }

    public enum IssueType
    {
        Bug,
        Comment,
        Important,
        TODO,
        Archive
    }


}