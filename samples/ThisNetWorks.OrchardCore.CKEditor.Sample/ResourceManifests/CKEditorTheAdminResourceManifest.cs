using OrchardCore.ResourceManagement;

namespace ThisNetWorks.OrchardCore.CKEditor.Sample.ResourceManifests
{
    /// <summary>
    /// This is an example of how to override the admin css
    /// We register existing adminstyles under an unused style name, set the corrected dependencies
    /// Then register admin with our own style sheet, and take a dependency on the newly defined theadmin stylesheet.
    /// </summary>
    public class CKEditorTheAdminResourceManifest : IResourceManifestProvider
    {
        public void BuildManifests(IResourceManifestBuilder builder)
        {
            var manifest = builder.Add();

            manifest
                .DefineStyle("theadmin")
                .SetUrl("~/TheAdmin/Styles/TheAdmin.min.css", "~/TheAdmin/Styles/TheAdmin.css")
                .SetDependencies("jQuery-ui");

            manifest
                .DefineStyle("admin")
                .SetUrl("~/styles/CKEditorAdminStyles.css", "~/styles/CKEditorAdminStyles.css")
                .SetDependencies("theadmin");
        }
    }
}