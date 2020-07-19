using OrchardCore.ResourceManagement;

namespace ThisNetWorks.OrchardCore.CKEditor.Sample.web.ResourceManifests
{
    /// <summary>
    /// This is an example of how to override the <script asp-name="ckeditorclassic"> tag helper
    /// Register this class as an IResourceManifestProvider with the urls to your custom build of CKEditor and it will replace the default custom build. 
    /// </summary>
    public class ClassicEditorResourceManifest : IResourceManifestProvider
    {
        public void BuildManifests(IResourceManifestBuilder builder)
        {
            var manifest = builder.Add();

            manifest
                .DefineScript("CKEditorClassic")
                .SetUrl("https://cdn.ckeditor.com/ckeditor5/20.0.0/classic/ckeditor.js")
                .SetCdn("https://cdn.ckeditor.com/ckeditor5/20.0.0/classic/ckeditor.js", "https://cdn.ckeditor.com/ckeditor5/20.0.0/classic/ckeditor.js")
                .SetVersion("20.0.0");
        }
    }
}