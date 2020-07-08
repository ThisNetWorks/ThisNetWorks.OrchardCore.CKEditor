using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OrchardCore.Admin;
using OrchardCore.ContentTypes.Editors;
using OrchardCore.Modules;
using OrchardCore.Mvc.Core.Utilities;
using OrchardCore.Navigation;
using OrchardCore.Security.Permissions;
using ThisNetWorks.OrchardCore.CKEditor.Controllers;
using ThisNetWorks.OrchardCore.CKEditor.Services;
using ThisNetWorks.OrchardCore.CKEditor.Settings;

namespace ThisNetWorks.OrchardCore.CKEditor
{
    public class Startup : StartupBase
    {
        private readonly AdminOptions _adminOptions;

        public Startup(IOptions<AdminOptions> adminOptions)
        {
            _adminOptions = adminOptions.Value;
        }
                
        public override void ConfigureServices(IServiceCollection services)
        {           
            services
                .AddScoped<CKEditorConfigurationManager>()
                .AddScoped<IPermissionProvider, Permissions>()
                .AddScoped<INavigationProvider, AdminMenu>()
                .AddScoped<IContentPartFieldDefinitionDisplayDriver, HtmlFieldCKEditorClassicSettingsDriver>()
                .AddScoped<IContentTypePartDefinitionDisplayDriver, HtmlBodyPartCKEditorClassicSettingsDriver>();

        }

        public override void Configure(IApplicationBuilder builder, IEndpointRouteBuilder routes, IServiceProvider serviceProvider)
        {
            var adminControllerName = typeof(AdminController).ControllerName();

            routes.MapAreaControllerRoute(
                name: "ThisNetWorksCKEditor",
                areaName: "ThisNetWorks.OrchardCore.CKEditor",
                pattern: _adminOptions.AdminUrlPrefix + "/CKEditor",
                defaults: new { controller = adminControllerName, action = nameof(AdminController.Index) }
            );
            routes.MapAreaControllerRoute(
                name: "ThisNetWorksCKEditorCreate",
                areaName: "ThisNetWorks.OrchardCore.CKEditor",
                pattern: _adminOptions.AdminUrlPrefix + "/CKEditor/Create/{name}",
                defaults: new { controller = adminControllerName, action = nameof(AdminController.Create) }
            );
            routes.MapAreaControllerRoute(
                name: "ThisNetWorksCKEditorEdit",
                areaName: "ThisNetWorks.OrchardCore.CKEditor",
                pattern: _adminOptions.AdminUrlPrefix + "/CKEditor/Edit/{name}",
                defaults: new { controller = adminControllerName, action = nameof(AdminController.Edit) }
            );
        }        
    }
}