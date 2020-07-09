using OrchardCore.Deployment;
using OrchardCore.DisplayManagement.Handlers;
using OrchardCore.DisplayManagement.Views;

namespace ThisNetWorks.OrchardCore.CKEditor.Deployment
{
    public class AllCKEditorConfigurationsDeploymentStepDriver : DisplayDriver<DeploymentStep, AllCKEditorConfigurationsDeploymentStep>
    {
        public override IDisplayResult Display(AllCKEditorConfigurationsDeploymentStep step)
        {
            return
                Combine(
                    View("AllCKEditorConfigurationsDeploymentStep_Summary", step).Location("Summary", "Content"),
                    View("AllCKEditorConfigurationsDeploymentStep_Thumbnail", step).Location("Thumbnail", "Content")
                );
        }

        public override IDisplayResult Edit(AllCKEditorConfigurationsDeploymentStep step)
        {
            return View("AllCKEditorConfigurationsDeploymentStep_Edit", step).Location("Content");
        }
    }
}
