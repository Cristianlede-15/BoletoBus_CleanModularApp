using BoletosBus_CleanModularApp.Web.Models.Base;
using BoletosBus_CleanModularApp.Web.Models.BusModels;
using BoletosBus_CleanModularApp.Web.Models.URL_s;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace BoletosBus_CleanModularApp.Web.Controllers
{
    public class BusController : Controller
    {
        private readonly ServicesAPI _services;
        private readonly ConfigurationURL_s _configurationURL_s;

        public BusController(ServicesAPI apiService, IOptions<ConfigurationURL_s> options)
        {
            _services = apiService;
            _configurationURL_s = options.Value;
        }

        // GET: BusController
        public async Task<ActionResult> Index()
        {
            try
            {
                var apiResponse = await _services.GetAsync<List<BusGetModel>>(_configurationURL_s.GetBuses);
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
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while fetching data: " + ex.Message);
                return View(new List<BusGetModel>());
            }
        }

        // GET: BusController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            try
            {
                var apiResponse = await _services.GetAsync<BusGetModel>(_configurationURL_s.GetBusById(id));
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
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while fetching data: " + ex.Message);
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
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(busCreateModel);
                }

                var apiResponse = await _services.PostAsync(_configurationURL_s.SaveBus, busCreateModel);

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
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while saving data: " + ex.Message);
                return View(busCreateModel);
            }
        }

        // GET: BusController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                var apiResponse = await _services.GetAsync<BusGetModel>(_configurationURL_s.GetBusById(id));
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
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while fetching data: " + ex.Message);
                return NotFound();
            }
        }

        // POST: BusController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, BusUpdateModel busUpdateModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(busUpdateModel);
                }

                var apiResponse = await _services.PostAsync(_configurationURL_s.GetBusById(id), busUpdateModel);

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
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while updating data: " + ex.Message);
                return View(busUpdateModel);
            }
        }

        // GET: BusController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var apiResponse = await _services.GetAsync<BusDeleteModel>(_configurationURL_s.GetBusById(id));
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
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while fetching data: " + ex.Message);
                return NotFound();
            }
        }

        // POST: BusController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                var apiResponse = await _services.DeleteAsync<BusDeleteModel>(_configurationURL_s.GetBusById(id));

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
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while deleting data: " + ex.Message);
                return View();
            }
        }
    }
}