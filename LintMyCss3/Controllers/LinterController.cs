using LintMyCss3.MyClasses;
using LintMyCss3.MyInterfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace LintMyCss3.Controllers
{
    public class LinterController : ApiController
    {
        Linter linter { get; set; } = new Linter(new List<LintChecker> { new ExpressionChecker("!important", WarningType.DisallowImportant), new ExpressionChecker("@import", WarningType.DisallowImport)  });
        // POST linter
        public JsonResult Post([FromBody] dynamic data)
        {
            var lintResults = linter.LintCssContent(data.content.ToString());

            return new JsonResult()
            {
                Data = new { warnings = lintResults.ToArray() },
                JsonRequestBehavior = JsonRequestBehavior.DenyGet
            };
        }
    }
}
