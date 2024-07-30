using BoletosBus_CleanModularApp.Web.Models.AsientoModels;
using BoletosBus_CleanModularApp.Web.Models.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Reflection;
using System.Text;

namespace BoletosBus_CleanModularApp.Web.Controllers
{
    public class AsientoController : Controller
    {
        private readonly ServicesAPI _services;

        public AsientoController(ServicesAPI apiService)
        {
            _services = apiService;
        }

        // GET: AsientoController
        public async Task<ActionResult> Index()
        {
            var apiResponse = await _services.GetAsync<List<AsientoGetModel>>("http://localhost:5254/api/Asiento/GetAsientos");
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
            var apiResponse = await _services.GetAsync<AsientoGetModel>($"http://localhost:5254/api/Asiento/GetAsientoById?id={id}");
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

            var apiResponse = await _services.PostAsync("http://localhost:5254/api/Asiento/SaveAsiento", asientoSaveModel);

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
            var apiResponse = await _services.GetAsync<AsientoGetModel>($"http://localhost:5254/api/Asiento/GetAsientoById?id={id}");
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

            var apiResponse = await _services.PostAsync($"http://localhost:5254/api/Asiento/UpdateAsiento?id={id}", asientoUpdateModel);

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
            var apiResponse = await _services.GetAsync<AsientoDeleteModel>($"http://localhost:5254/api/Asiento/GetAsientoById?id={id}");
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
            var apiResponse = await _services.DeleteAsync<AsientoDeleteModel>($"http://localhost:5254/api/Asiento/DeleteAsiento?id={id}");

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
