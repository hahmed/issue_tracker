using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace IssueTracker.Models
{


    public class Issue
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime When { get; set; }

        public IssueType TypeOfIssue { get; set; }

        /// <summary>
        /// email of user who submitted request
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// authors name
        /// </summary>
        public string Author { get; set; }


        public static bool IsValidEmail(string strIn)
        {
            if (String.IsNullOrEmpty(strIn))
                return false;

            // Return true if strIn is in valid e-mail format. 
            try
            {
                return Regex.IsMatch(strIn,
                      @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                      @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$",
                      RegexOptions.IgnoreCase);
            }
            catch (Exception)
            {
                return false;
            }
        }
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