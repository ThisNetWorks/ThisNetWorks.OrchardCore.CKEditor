using System.Threading.Tasks;
using ThisNetWorks.OrchardCore.CKEditor.Models;
using OrchardCore.Documents;

namespace ThisNetWorks.OrchardCore.CKEditor.Services
{
    public class CKEditorConfigurationManager
    {

        private readonly IDocumentManager<CKEditorConfigurationDocument> _documentManager;

        public CKEditorConfigurationManager(IDocumentManager<CKEditorConfigurationDocument> documentManager) => _documentManager = documentManager;

        /// <summary>
        /// Loads the templates document from the store for updating and that should not be cached.
        /// </summary>
        public Task<CKEditorConfigurationDocument> LoadDocumentAsync() => _documentManager.GetOrCreateMutableAsync();

        /// <summary>
        /// Gets the templates document from the cache for sharing and that should not be updated.
        /// </summary>
        public Task<CKEditorConfigurationDocument> GetDocumentAsync() => _documentManager.GetOrCreateImmutableAsync();        


        public async Task RemoveAsync(string name)
        {
            var document = await LoadDocumentAsync();
            document.Configurations.Remove(name);
            await _documentManager.UpdateAsync(document);
        }

        public async Task UpdateAsync(string name, CKEditorConfiguration configuration)
        {
            var document = await LoadDocumentAsync();
            document.Configurations[name] = configuration;
            await _documentManager.UpdateAsync(document);
        }
    }
}
