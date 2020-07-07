using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OrchardCore.ResourceManagement;
using ThisNetWorks.OrchardCore.CKEditor.Sample.ResourceManifests;

namespace ThisNetWorks.OrchardCore.CKEditor.Sample
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOrchardCms()

                /// This is an example of how to override the <script asp-name="ckeditorclassic"> tag helper
                /// Register a IResourceManifestProvider with the urls to your custom build of CKEditor and it will replace the default custom build registration in the editor view.             
                // .ConfigureServices(tenantServices => tenantServices.AddScoped<IResourceManifestProvider, ClassicEditorResourceManifest>())
                ;
        }
        
        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseOrchardCore();
        }
    }
}
