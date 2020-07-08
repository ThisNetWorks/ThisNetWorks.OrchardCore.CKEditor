using System;
using System.Collections.Generic;

namespace ThisNetWorks.OrchardCore.CKEditor.Models
{
    public class CKEditorConfigurationDocument
    {
        public Dictionary<string, CKEditorConfiguration> Configurations { get; } = new Dictionary<string, CKEditorConfiguration>(StringComparer.OrdinalIgnoreCase);
    }
}
