using Microsoft.Extensions.Options;
using OrchardCore.ResourceManagement;

namespace ThisNetWorks.OrchardCore.CKEditor.Sample.Web.ResourceManifests
{
    /// <summary>
    /// This is an example of how to override the admin css
    /// We register existing adminstyles under an unused style name, set the corrected dependencies
    /// Then register admin with our own style sheet, and take a dependency on the newly defined theadmin stylesheet.
    /// </summary>
    public class CKEditorTheAdminResourceManagementOptionsConfiguration : IConfigureOptions<ResourceManagementOptions>
    {
        private static ResourceManifest _theAdminManifest;
        private static ResourceManifest _adminManifest;

        static CKEditorTheAdminResourceManagementOptionsConfiguration()
        {
            _theAdminManifest = new ResourceManifest();

            _theAdminManifest
                .DefineStyle("theadmin")
                .SetUrl("~/TheAdmin/Styles/TheAdmin.min.css", "~/TheAdmin/Styles/TheAdmin.css")
                .SetDependencies("jQuery-ui");

            _adminManifest = new ResourceManifest();

            _adminManifest
                    .DefineStyle("admin")
                    .SetUrl("~/styles/CKEditorAdminStyles.css", "~/styles/CKEditorAdminStyles.css")
                    .SetDependencies("theadmin");
        }

        public void Configure(ResourceManagementOptions options)
        {
            options.ResourceManifests.Add(_theAdminManifest);
            options.ResourceManifests.Add(_adminManifest);
        }
    }
}
