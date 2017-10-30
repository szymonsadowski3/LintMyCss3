using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LintMyCss3.MyClasses
{
    public enum WarningType {
        DisallowImportant,
        DisallowImport,
        BoxModelSize
    };

    public static class WarningTypeDescriptioner
    {
        public static Dictionary<WarningType, string> mappingWarningTypeToDescription = new Dictionary<WarningType, string>()
        {
            {WarningType.DisallowImportant, "You should not use !important directive!" },
            {WarningType.DisallowImport, "You should not use @import directive!" },
            {WarningType.BoxModelSize, "You can encounter problems with box model size!" }
        };
    };

    
}