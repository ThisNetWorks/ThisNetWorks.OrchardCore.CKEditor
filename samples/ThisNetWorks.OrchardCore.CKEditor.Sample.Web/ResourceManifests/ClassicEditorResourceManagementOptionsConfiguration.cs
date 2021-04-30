using Microsoft.Extensions.Options;
using OrchardCore.ResourceManagement;

namespace ThisNetWorks.OrchardCore.CKEditor.Sample.Web.ResourceManifests
{
    /// <summary>
    /// This is an example of how to override the <script asp-name="ckeditorclassic"> tag helper
    /// Register this class as an IResourceManifestProvider with the urls to your custom build of CKEditor and it will replace the default custom build. 
    /// </summary>
    public class ClassicEditorResourceManagementOptionsConfiguration : IConfigureOptions<ResourceManagementOptions>
    {
        private static ResourceManifest _manifest;

        static ClassicEditorResourceManagementOptionsConfiguration()
        {
            _manifest = new ResourceManifest();

            _manifest
                .DefineScript("CKEditorClassic")
                .SetUrl("https://cdn.ckeditor.com/ckeditor5/20.0.0/classic/ckeditor.js")
                .SetCdn("https://cdn.ckeditor.com/ckeditor5/20.0.0/classic/ckeditor.js", "https://cdn.ckeditor.com/ckeditor5/20.0.0/classic/ckeditor.js")
                .SetVersion("20.0.0");

        }

        public void Configure(ResourceManagementOptions options)
        {
            options.ResourceManifests.Add(_manifest);
        }
    }
}