using BoletosBus_CleanModularApp.Web.Models.AsientoModels;
using BoletosBus_CleanModularApp.Web.Models.Base;
using BoletosBus_CleanModularApp.Web.Models.URL_s;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace BoletosBus_CleanModularApp.Web.Controllers
{
    public class AsientoController : Controller
    {
        private readonly ServicesAPI _services;
        private readonly ConfigurationURL_s _configurationURL_s;

        public AsientoController(ServicesAPI apiService, IOptions<ConfigurationURL_s> options)
        {
            _services = apiService;
            _configurationURL_s = options.Value;
        }

        // GET: AsientoController
        public async Task<ActionResult> Index()
        {
            var apiResponse = await _services.GetAsync<List<AsientoGetModel>>(_configurationURL_s.GetAsientos);
            if (apiResponse.Success)
            {
                return View(apiResponse.Data);
            }
            else
            {
                ModelState.AddModelError(string.Empty, apiResponse.Message);
                return View(new List<AsientoGetModel>());
            }
        }

        // GET: AsientoController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var apiResponse = await _services.GetAsync<AsientoGetModel>(_configurationURL_s.GetAsientoById(id));
            if (apiResponse.Success)
            {
                return View(apiResponse.Data);
            }
            else
            {
                ModelState.AddModelError(string.Empty, apiResponse.Message);
                return NotFound();
            }
        }

        // GET: AsientoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AsientoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AsientoSaveModel asientoSaveModel)
        {
            if (!ModelState.IsValid)
            {
                return View(asientoSaveModel);
            }

            var apiResponse = await _services.PostAsync(_configurationURL_s.SaveAsiento, asientoSaveModel);

            if (apiResponse.Success)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ModelState.AddModelError(string.Empty, apiResponse.Message);
                return View(asientoSaveModel);
            }
        }

        // GET: AsientoController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var apiResponse = await _services.GetAsync<AsientoGetModel>(_configurationURL_s.GetAsientoById(id));
            if (apiResponse.Success)
            {
                var asientoUpdateModel = new AsientoUpdateModel
                {
                    IdAsiento = apiResponse.Data.Id,
                    IdBus = apiResponse.Data.IdBus,
                    NumeroPiso = apiResponse.Data.NumeroPiso,
                    NumeroAsiento = apiResponse.Data.NumeroAsiento,
                    Disponible = apiResponse.Data.Disponible
                };

                return View(asientoUpdateModel);
            }
            else
            {
                ModelState.AddModelError(string.Empty, apiResponse.Message);
                return NotFound();
            }
        }

        // POST: AsientoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, AsientoUpdateModel asientoUpdateModel)
        {
            if (!ModelState.IsValid)
            {
                return View(asientoUpdateModel);
            }

            var apiResponse = await _services.PostAsync(_configurationURL_s.GetAsientoById(id), asientoUpdateModel);

            if (apiResponse.Success)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ModelState.AddModelError(string.Empty, apiResponse.Message);
                return View(asientoUpdateModel);
            }
        }

        // GET: AsientoController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var apiResponse = await _services.GetAsync<AsientoDeleteModel>(_configurationURL_s.GetAsientoById(id));
            if (apiResponse.Success)
            {
                return View(apiResponse.Data);
            }
            else
            {
                ModelState.AddModelError(string.Empty, apiResponse.Message);
                return NotFound();
            }
        }

        // POST: AsientoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            var apiResponse = await _services.DeleteAsync<AsientoDeleteModel>(_configurationURL_s.GetAsientoById(id));

            if (apiResponse.Success)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ModelState.AddModelError(string.Empty, apiResponse.Message);
                return View();
            }
        }
    }
}
