using LintMyCss3.MyClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LintMyCss3.MyInterfaces
{
    public interface LintChecker
    {
        IEnumerable<Warning> GetWarnings(string cssContent);
    }
}
