using System;
using Newtonsoft.Json;

namespace ThisNetWorks.OrchardCore.CKEditor.Models
{
    public class CKEditorConfiguration
    {
        /// <summary>
        /// True if the object can't be used to update the database.
        /// </summary>
        [JsonIgnore]
        public bool IsReadonly { get; set; }

        public string Name { get; set; } = String.Empty;
        public string Configuration { get; set; }
    }
}
