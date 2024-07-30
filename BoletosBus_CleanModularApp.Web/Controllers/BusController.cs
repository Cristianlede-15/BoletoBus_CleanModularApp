using BoletosBus_CleanModularApp.Web.Models.Base;
using BoletosBus_CleanModularApp.Web.Models.BusModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BoletosBus_CleanModularApp.Web.Controllers
{
    public class BusController : Controller
    {
        private readonly ServicesAPI _services;

        public BusController(ServicesAPI apiService)
        {
            _services = apiService;
        }

        // GET: BusController
        public async Task<ActionResult> Index()
        {
            var apiResponse = await _services.GetAsync<List<BusGetModel>>("http://localhost:5005/api/Bus/GetBuses");
            if (apiResponse.Success)
            {
                return View(apiResponse.Data);
            }
            else
            {
                ModelState.AddModelError(string.Empty, apiResponse.Message);
                return View(new List<BusGetModel>());
            }
        }

        // GET: BusController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var apiResponse = await _services.GetAsync<BusGetModel>($"http://localhost:5005/api/Bus/GetBusById?id={id}");
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

        // GET: BusController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BusController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(BusCreateModel busCreateModel)
        {
            if (!ModelState.IsValid)
            {
                return View(busCreateModel);
            }

            var apiResponse = await _services.PostAsync("http://localhost:5005/api/Bus", busCreateModel);

            if (apiResponse.Success)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ModelState.AddModelError(string.Empty, apiResponse.Message);
                return View(busCreateModel);
            }
        }

        // GET: BusController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var apiResponse = await _services.GetAsync<BusGetModel>($"http://localhost:5005/api/Bus/GetBusById?id={id}");
            if (apiResponse.Success)
            {
                var busUpdateModel = new BusUpdateModel
                {
                    IdBus = apiResponse.Data.IdBus,
                    NumeroPlaca = apiResponse.Data.NumeroPlaca,
                    Nombre = apiResponse.Data.Nombre,
                    CapacidadPiso1 = apiResponse.Data.CapacidadPiso1,
                    CapacidadPiso2 = apiResponse.Data.CapacidadPiso2,
                    Disponible = apiResponse.Data.Disponible

                };

                return View(busUpdateModel);
            }
            else
            {
                ModelState.AddModelError(string.Empty, apiResponse.Message);
                return NotFound();
            }
        }

        // POST: BusController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, BusUpdateModel busUpdateModel)
        {
            if (!ModelState.IsValid)
            {
                return View(busUpdateModel);
            }

            var apiResponse = await _services.PostAsync($"http://localhost:5005/api/Bus/UpdateBus?id={id}", busUpdateModel);

            if (apiResponse.Success)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ModelState.AddModelError(string.Empty, apiResponse.Message);
                return View(busUpdateModel);
            }
        }

        // GET: BusController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var apiResponse = await _services.GetAsync<BusDeleteModel>($"http://localhost:5005/api/Bus/GetBusById?id={id}");
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

        // POST: BusController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            var apiResponse = await _services.DeleteAsync<BusDeleteModel>($"http://localhost:5005/api/Bus/DeleteBus?id={id}");

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