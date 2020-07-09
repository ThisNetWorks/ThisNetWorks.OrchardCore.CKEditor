using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using OrchardCore.Recipes.Models;
using OrchardCore.Recipes.Services;
using ThisNetWorks.OrchardCore.CKEditor.Models;
using ThisNetWorks.OrchardCore.CKEditor.Services;

namespace ThisNetWorks.OrchardCore.CKEditor.Recipes
{
    /// <summary>
    /// This recipe step creates a set of CKEditor Configurations.
    /// </summary>
    public class CKEditorConfigurationsStep : IRecipeStepHandler
    {
        private readonly CKEditorConfigurationManager _configurationManager;

        public CKEditorConfigurationsStep(CKEditorConfigurationManager configurationManager)
        {
            _configurationManager = configurationManager;
        }

        public async Task ExecuteAsync(RecipeExecutionContext context)
        {
            if (!String.Equals(context.Name, "CKEditorConfigurations", StringComparison.OrdinalIgnoreCase))
            {
                return;
            }

            if (context.Step.Property("CKEditorConfigurations").Value is JObject configurations)
            {
                foreach (var property in configurations.Properties())
                {
                    var name = property.Name;
                    var value = property.Value.ToObject<CKEditorConfiguration>();

                    await _configurationManager.UpdateAsync(name, value);
                }
            }
        }
    }
}
