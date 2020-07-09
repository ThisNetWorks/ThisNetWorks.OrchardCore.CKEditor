using OrchardCore.Deployment;

namespace ThisNetWorks.OrchardCore.CKEditor.Deployment
{
    /// <summary>
    /// Adds configurations to a <see cref="DeploymentPlanResult"/>.
    /// </summary>
    public class AllCKEditorConfigurationsDeploymentStep : DeploymentStep
    {
        public AllCKEditorConfigurationsDeploymentStep()
        {
            Name = "AllCKEditorConfigurations";
        }
    }
}
