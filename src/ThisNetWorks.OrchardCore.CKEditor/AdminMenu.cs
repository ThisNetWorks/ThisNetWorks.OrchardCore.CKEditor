using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;
using OrchardCore.Navigation;

namespace ThisNetWorks.OrchardCore.CKEditor
{
    public class AdminMenu : INavigationProvider
    {
        private readonly IStringLocalizer S;

        public AdminMenu(IStringLocalizer<AdminMenu> localizer)
        {
            S = localizer;
        }

        public Task BuildNavigationAsync(string name, NavigationBuilder builder)
        {
            if (!String.Equals(name, "admin", StringComparison.OrdinalIgnoreCase))
            {
                return Task.CompletedTask;
            }

            builder
                .Add(S["Configuration"], design => design
                    .Add(S["CKEditor Configurations"], "CKEditor Configurations", import => import
                        .Action("Index", "Admin", new { area = "ThisNetWorks.OrchardCore.CKEditor" })
                        .Permission(Permissions.ManageCKEditorConfigurations)
                        .LocalNav()
                    )
                );

            return Task.CompletedTask;
        }
    }
}