using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Primitives;
using ThisNetWorks.OrchardCore.CKEditor.Models;
using OrchardCore.Data;
using OrchardCore.Environment.Cache;
using YesSql;

namespace ThisNetWorks.OrchardCore.CKEditor.Services
{
    public class CKEditorConfigurationManager
    {
        private const string CacheKey = nameof(CKEditorConfigurationManager);

        private readonly ISignal _signal;
        private readonly ISession _session;
        private readonly ISessionHelper _sessionHelper;
        private readonly IMemoryCache _memoryCache;

        public CKEditorConfigurationManager(
            ISignal signal,
            ISession session,
            ISessionHelper sessionHelper,
            IMemoryCache memoryCache)
        {
            _signal = signal;
            _session = session;
            _sessionHelper = sessionHelper;
            _memoryCache = memoryCache;
        }

        public IChangeToken ChangeToken => _signal.GetToken(CacheKey);

        /// <summary>
        /// Returns the document from the database to be updated.
        /// </summary>
        public Task<CKEditorConfigurationDocument> LoadDocumentAsync() => _sessionHelper.LoadForUpdateAsync<CKEditorConfigurationDocument>();

        /// <summary>
        /// Returns the document from the cache or creates a new one. The result should not be updated.
        /// </summary>
        /// <inheritdoc/>
        public async Task<CKEditorConfigurationDocument> GetDocumentAsync()
        {
            if (!_memoryCache.TryGetValue<CKEditorConfigurationDocument>(CacheKey, out var document))
            {
                var changeToken = ChangeToken;
                
                bool cacheable;
                (cacheable, document) = await _sessionHelper.GetForCachingAsync<CKEditorConfigurationDocument>();

                if (cacheable)
                {
                    foreach (var configuration in document.Configurations.Values)
                    {
                        configuration.IsReadonly = true;
                    }

                    _memoryCache.Set(CacheKey, document, changeToken);
                }
            }

            return document;
        }

        public async Task RemoveAsync(string name)
        {
            var document = await LoadDocumentAsync();
            document.Configurations.Remove(name);

            _session.Save(document);
            _signal.DeferredSignalToken(CacheKey);
        }

        public async Task UpdateAsync(string name, CKEditorConfiguration configuration)
        {
            if (configuration.IsReadonly)
            {
                throw new ArgumentException("The object is read-only");
            }

            var document = await LoadDocumentAsync();
            document.Configurations[name] = configuration;

            _session.Save(document);
            _signal.DeferredSignalToken(CacheKey);
        }
    }
}
