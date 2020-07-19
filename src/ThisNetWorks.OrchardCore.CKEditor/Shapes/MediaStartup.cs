using Microsoft.Extensions.DependencyInjection;
using OrchardCore.DisplayManagement.Descriptors;
using OrchardCore.Modules;

namespace ThisNetWorks.OrchardCore.CKEditor.Shapes
{
    [Feature("ThisNetWorks.OrchardCore.CKEditor")]
    [RequireFeatures("OrchardCore.Media")]
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IShapeTableProvider, HtmlMediaShapes>();
        }
    }
}
