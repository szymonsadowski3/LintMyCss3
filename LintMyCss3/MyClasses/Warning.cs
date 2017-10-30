using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LintMyCss3.MyClasses
{
    public class Warning
    {
        public Warning(WarningType warningType, int column, int line, string description)
        {
            this.Type = warningType;
            this.Column = column;
            this.Line = line;
            this.Description = description;
        }

        public WarningType Type { get; set; }
        public int Column { get; set; }
        public int Line { get; set; }
        public string Description { get; set; }

        public override string ToString() {
            return $"(Type = {this.Type}, Column = {this.Column}, Line = {this.Line}, Description = {this.Description})";
        }
    
        public override bool Equals(object obj)
        {
            return Equals(obj as Warning);
        }
        public bool Equals(Warning obj)
        {
            return (this.Type == obj.Type && this.Column == obj.Column && this.Line == obj.Line);
        }
    }
}