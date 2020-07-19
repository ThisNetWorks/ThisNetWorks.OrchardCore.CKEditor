using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using Newtonsoft.Json.Linq;
using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentManagement.Metadata.Models;
using OrchardCore.ContentTypes.Editors;
using OrchardCore.DisplayManagement.Views;
using ThisNetWorks.OrchardCore.CKEditor.Services;
using ThisNetWorks.OrchardCore.CKEditor.ViewModels;

namespace ThisNetWorks.OrchardCore.CKEditor.Settings
{
    public class HtmlFieldCKEditorClassicSettingsDriver : ContentPartFieldDefinitionDisplayDriver<HtmlField>
    {
        private readonly CKEditorConfigurationManager _manager;
        private readonly IStringLocalizer S;

        public HtmlFieldCKEditorClassicSettingsDriver(
            CKEditorConfigurationManager manager,
            IStringLocalizer<HtmlFieldCKEditorClassicSettingsDriver> localizer)
        {
            _manager = manager;
            S = localizer;
        }

        public override IDisplayResult Edit(ContentPartFieldDefinition partFieldDefinition)
        {
            return Initialize<HtmlFieldCKEditorClassicSettingsViewModel>("HtmlFieldCKEditorEditorClassicSettings_Edit", async model =>
            {
                var settings = partFieldDefinition.GetSettings<HtmlFieldCKEditorClassicSettings>();

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

        public override async Task<IDisplayResult> UpdateAsync(ContentPartFieldDefinition partFieldDefinition, UpdatePartFieldEditorContext context)
        {
            if (partFieldDefinition.Editor() == "CKEditorClassic")
            {
                var model = new HtmlFieldCKEditorClassicSettingsViewModel();
                var settings = new HtmlFieldCKEditorClassicSettings();

                await context.Updater.TryUpdateModelAsync(model, Prefix, m => m.SelectedConfigurationName);

                settings.ConfigurationName = model.SelectedConfigurationName;
               
                context.Builder.WithSettings(settings);
            }

            return Edit(partFieldDefinition);
        }
    }
}
