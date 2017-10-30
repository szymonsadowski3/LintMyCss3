using LintMyCss3.MyInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LintMyCss3.MyClasses
{
    public class ExpressionChecker : LintChecker
    {
        public string Expression { get; set; }
        public WarningType TypeOfError { get; set; }
        public ExpressionChecker(string expression, WarningType typeOfError)
        {
            this.Expression = expression;
            this.TypeOfError = typeOfError;
        }
        public IEnumerable<Warning> GetWarnings(string cssContent)
        {
            List<Warning> warnings = new List<Warning>();
            var splitResults = cssContent.Split(new string[] { System.Environment.NewLine }, System.StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < splitResults.Length; i++)
            {
                var splitResult = splitResults[i];

                int numOfCharactersAbsorbedSoFar = 0;
                for (; ; )
                {
                    int indexOfOcurrence = splitResult.IndexOf(this.Expression);

                    if (indexOfOcurrence != -1)
                    {
                        int endingIndexOfOcurrence = indexOfOcurrence + this.Expression.Length;
                        warnings.Add(new Warning(this.TypeOfError, indexOfOcurrence + numOfCharactersAbsorbedSoFar + 1, i, WarningTypeDescriptioner.mappingWarningTypeToDescription[this.TypeOfError]));
                        splitResult = splitResult.Substring(endingIndexOfOcurrence);
                        numOfCharactersAbsorbedSoFar += endingIndexOfOcurrence;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return warnings;
        }
    }
}