using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using Newtonsoft.Json.Linq;
using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentManagement.Metadata.Models;
using OrchardCore.ContentTypes.Editors;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Views;
using OrchardCore.Html.Models;
using ThisNetWorks.OrchardCore.CKEditor.Services;
using ThisNetWorks.OrchardCore.CKEditor.ViewModels;

namespace ThisNetWorks.OrchardCore.CKEditor.Settings
{
    public class HtmlBodyPartCKEditorClassicSettingsDriver : ContentTypePartDefinitionDisplayDriver
    {
        private readonly CKEditorConfigurationManager _manager;
        private readonly IStringLocalizer S;

        public HtmlBodyPartCKEditorClassicSettingsDriver(
            CKEditorConfigurationManager manager,
            IStringLocalizer<HtmlBodyPartCKEditorClassicSettingsDriver> localizer)
        {
            _manager = manager;
            S = localizer;
        }

        public override IDisplayResult Edit(ContentTypePartDefinition contentTypePartDefinition, IUpdateModel updater)
        {
            if (!String.Equals(nameof(HtmlBodyPart), contentTypePartDefinition.PartDefinition.Name))
            {
                return null;
            }
                        
            return Initialize<HtmlBodyPartCKEditorClassicSettingsViewModel>("HtmlBodyPartCKEditorEditorClassicSettings_Edit", async model =>
            {
                var settings = contentTypePartDefinition.GetSettings<HtmlBodyPartCKEditorClassicSettings>();

                var document = await _manager.GetDocumentAsync();
                model.Configurations.Add(new SelectListItem{ Text = S["Default Configuration"], Value = String.Empty });
                model.Configurations.AddRange(document.Configurations.Keys.Select(x => new SelectListItem{ Text = x, Value = x }).ToList());
                if (!String.IsNullOrEmpty(settings.ConfigurationName) && document.Configurations.ContainsKey(settings.ConfigurationName))
                {
                    model.SelectedConfigurationName = settings.ConfigurationName;
                }
            })
            .Location("Editor");
        }

        public override async Task<IDisplayResult> UpdateAsync(ContentTypePartDefinition contentTypePartDefinition, UpdateTypePartEditorContext context)
        {
            if (!String.Equals(nameof(HtmlBodyPart), contentTypePartDefinition.PartDefinition.Name))
            {
                return null;
            }

            if (contentTypePartDefinition.Editor() == "CKEditorClassic")
            {
                var model = new HtmlBodyPartCKEditorClassicSettingsViewModel();
                var settings = new HtmlBodyPartCKEditorClassicSettings();

                await context.Updater.TryUpdateModelAsync(model, Prefix, m => m.SelectedConfigurationName);

                settings.ConfigurationName = model.SelectedConfigurationName;
               
                context.Builder.WithSettings(settings);
            }

            return Edit(contentTypePartDefinition);
        }
    }
}
