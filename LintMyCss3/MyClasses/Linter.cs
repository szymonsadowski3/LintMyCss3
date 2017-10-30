using LintMyCss3.MyClasses;
using LintMyCss3.MyInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LintMyCss3
{
    public class Linter
    {
        public IEnumerable<LintChecker> LintCheckers { get; set; }
        public Linter(IEnumerable<LintChecker> lintCheckers)
        {
            this.LintCheckers = lintCheckers;
        }

        public IEnumerable<Warning> LintCssContent(string content)
        {
            List<Warning> warnings = new List<Warning>();

            foreach (LintChecker lintChecker in this.LintCheckers)
            {
                warnings.AddRange(lintChecker.GetWarnings(content));
            }

            return warnings;
        } 
    }
}