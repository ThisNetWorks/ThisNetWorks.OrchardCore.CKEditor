using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Localization;
using Newtonsoft.Json.Linq;
using OrchardCore.Admin;
using OrchardCore.DisplayManagement;
using OrchardCore.DisplayManagement.Notify;
using OrchardCore.Environment.Shell;
using OrchardCore.Navigation;
using OrchardCore.Routing;
using OrchardCore.Settings;
using ThisNetWorks.OrchardCore.CKEditor.Models;
using ThisNetWorks.OrchardCore.CKEditor.Services;
using ThisNetWorks.OrchardCore.CKEditor.ViewModels;

namespace ThisNetWorks.OrchardCore.CKEditor.Controllers
{
    public class AdminController : Controller
    {
        private readonly string _tenant;
        private readonly IAuthorizationService _authorizationService;
        private readonly CKEditorConfigurationManager _ckEditorConfigurationManager;
        private readonly ISiteService _siteService;
        private readonly IStringLocalizer S;
        private readonly dynamic New;

        public AdminController(
            ShellSettings shellSettings,
            IAuthorizationService authorizationService,
            CKEditorConfigurationManager ckEditorConfigurationManager,
            IShapeFactory shapeFactory,
            ISiteService siteService,
            IStringLocalizer<AdminController> stringLocalizer,
            INotifier notifier)
        {
            _tenant = shellSettings.Name;
            _authorizationService = authorizationService;
            _ckEditorConfigurationManager = ckEditorConfigurationManager;
            New = shapeFactory;
            _siteService = siteService;
            S = stringLocalizer;
        }

        public async Task<IActionResult> Index(CKEditorConfigurationIndexOptions options, PagerParameters pagerParameters)
        {
            if (!await _authorizationService.AuthorizeAsync(User, Permissions.ManageCKEditorConfigurations))
            {
                return Forbid();
            }

            var siteSettings = await _siteService.GetSiteSettingsAsync();
            var pager = new Pager(pagerParameters, siteSettings.PageSize);
            
            // default options
            if (options == null)
            {
                options = new CKEditorConfigurationIndexOptions();
            }

            var document = await _ckEditorConfigurationManager.GetDocumentAsync();

            var configurationEntries = document.Configurations.Values.Select(x => new CKEditorConfigurationEntry { Configuration = x} )
                .OrderBy(entry => entry.Configuration.Name)
                .Skip(pager.GetStartIndex())
                .Take(pager.PageSize)
                .ToList();


            var pagerShape = (await New.Pager(pager)).TotalItemCount(configurationEntries.Count());

            var model = new CKEditorConfigurationIndexViewModel
            {
                Configurations = configurationEntries,
                Options = options,
                Pager = pagerShape
            };

            return View(model);
        }

        [HttpPost, ActionName("Index")]
        [FormValueRequired("submit.Filter")]
        public ActionResult IndexFilterPOST(CKEditorConfigurationIndexViewModel model)
        {
            return RedirectToAction("Index", new RouteValueDictionary {
                { "Options.Search", model.Options.Search }
            });
        }
        public async Task<IActionResult> Create(string name)
        {
            if (!await _authorizationService.AuthorizeAsync(User, Permissions.ManageCKEditorConfigurations))
            {
                return Forbid();
            }

            var model = new CKEditorConfigurationViewModel
            {
                Name = name
            };

            return View(model);
        }

        [HttpPost, ActionName("Create")]
        public async Task<IActionResult> CreatePost(CKEditorConfigurationViewModel model)
        {
            if (!await _authorizationService.AuthorizeAsync(User, Permissions.ManageCKEditorConfigurations))
            {
                return Forbid();
            }

            if (ModelState.IsValid)
            {
                if (String.IsNullOrWhiteSpace(model.Name))
                {
                    ModelState.AddModelError(nameof(CKEditorConfigurationViewModel.Name), S["The name is mandatory."]);
                }
                if (!IsJsonOrWhitespace(model.Configuration))
                {
                    ModelState.AddModelError(nameof(CKEditorConfigurationViewModel.Configuration), S["Invalid JSON configuration."]);
                }                
            }

            if (ModelState.IsValid)
            {
                var document = await _ckEditorConfigurationManager.GetDocumentAsync();    
                if (document.Configurations.ContainsKey(model.Name))
                {
                    ModelState.AddModelError(nameof(CKEditorConfigurationViewModel.Name), S["A configuration with the same name already exists."]);
                }
                else
                {
                    var configuration = new CKEditorConfiguration
                    {
                        Name = model.Name,
                        Configuration = FormatJson(model.Configuration)
                    };

                    await _ckEditorConfigurationManager.UpdateAsync(model.Name, configuration);
                }

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public async Task<IActionResult> Edit(string name)
        {
            if (!await _authorizationService.AuthorizeAsync(User, Permissions.ManageCKEditorConfigurations))
            {
                return Forbid();
            }

            var document = await _ckEditorConfigurationManager.GetDocumentAsync();

            if (!document.Configurations.ContainsKey(name))
            {
                return RedirectToAction("Create", new { name });
            }


            var configuration = document.Configurations[name];

            var model = new CKEditorConfigurationViewModel
            {
                Name = name,
                Configuration = configuration.Configuration
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CKEditorConfigurationViewModel model)
        {
            if (!await _authorizationService.AuthorizeAsync(User, Permissions.ManageCKEditorConfigurations))
            {
                return Forbid();
            }

            if (ModelState.IsValid)
            {
                if (String.IsNullOrWhiteSpace(model.Name))
                {
                    ModelState.AddModelError(nameof(CKEditorConfigurationViewModel.Name), S["The name is mandatory."]);
                }
                if (!IsJsonOrWhitespace(model.Configuration))
                {
                    ModelState.AddModelError(nameof(CKEditorConfigurationViewModel.Configuration), S["Invalid JSON configuration."]);
                }                  
            }

            if (ModelState.IsValid)
            {
                var configuration = new CKEditorConfiguration
                {
                    Name = model.Name,
                    Configuration = FormatJson(model.Configuration)
                };

                await _ckEditorConfigurationManager.UpdateAsync(model.Name, configuration);

                return RedirectToAction(nameof(Index));
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string name)
        {
            if (!await _authorizationService.AuthorizeAsync(User, Permissions.ManageCKEditorConfigurations))
            {
                return Forbid();
            }

            var document = await _ckEditorConfigurationManager.LoadDocumentAsync();

            if (!document.Configurations.ContainsKey(name))
            {
                return NotFound();
            }

            await _ckEditorConfigurationManager.RemoveAsync(name);

            return RedirectToAction(nameof(Index));
        }

        private bool IsJsonOrWhitespace(string json)
        { 
            if (String.IsNullOrWhiteSpace(json))
            {
                return true;
            }

            try
            {
                JToken.Parse(json);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private string FormatJson(string json)
        {
            var jObject = JObject.Parse(json);
            return jObject.ToString(Newtonsoft.Json.Formatting.Indented);
        }
    }
}
