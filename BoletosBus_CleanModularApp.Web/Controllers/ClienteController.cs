using BoletosBus_CleanModularApp.Web.Models.Base;
using BoletosBus_CleanModularApp.Web.Models.ClienteModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BoletosBus_CleanModularApp.Web.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ServicesAPI _services;

        public ClienteController(ServicesAPI apiService)
        {
            _services = apiService;
        }

        // GET: ClienteController
        public async Task<ActionResult> Index()
        {
            var apiResponse = await _services.GetAsync<List<ClienteAccessModel>>("http://localhost:5231/api/Cliente/GetClientes\r\n");
            if (apiResponse.Success)
            {
                return View(apiResponse.Data);
            }
            else
            {
                ModelState.AddModelError(string.Empty, apiResponse.Message);
                return View(new List<ClienteAccessModel>());
            }
        }

        // GET: ClienteController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var apiResponse = await _services.GetAsync<ClienteAccessModel>($"http://localhost:5231/api/Cliente/GetClienteById?id={id}");
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

        // GET: ClienteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ClienteCreateModel clienteCreateModel)
        {
            if(!ModelState.IsValid)
            {
                return View(clienteCreateModel);
            }

            var apiResponse = await _services.PostAsync("http://localhost:5231/api/Cliente/CreateCliente", clienteCreateModel);
            if (apiResponse.Success)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ModelState.AddModelError(string.Empty, apiResponse.Message);
                return View(clienteCreateModel);
            }
        }

        // GET: ClienteController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var apiResponse = await _services.GetAsync<ClienteAccessModel>($"http://localhost:5231/api/Cliente/GetClienteById?id={id}");
            if (apiResponse.Success)
            {
                var clienteUpdateModel = new ClienteUpdateModel
                {
                    IdCliente = apiResponse.Data.IdCliente,
                    Nombre = apiResponse.Data.Nombre,
                    Telefono = apiResponse.Data.Telefono,
                    Email = apiResponse.Data.Email
                };
                return View(clienteUpdateModel);

            }
            else
            {
                ModelState.AddModelError(string.Empty, apiResponse.Message);
                return NotFound();
            }
        }

        // POST: ClienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, ClienteUpdateModel clienteUpdateModel)
        {
            if (!ModelState.IsValid)
            {
                return View(clienteUpdateModel);
            }

            var apiResponse = await _services.PostAsync($"http://localhost:5231/api/Cliente/UpdateCliente?id={id}", clienteUpdateModel);
            if (apiResponse.Success)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ModelState.AddModelError(string.Empty, apiResponse.Message);
                return View(clienteUpdateModel);
            }
        }

        // GET: ClienteController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var apiResponse = await _services.GetAsync<ClienteDeleteModel>($"http://localhost:5231/api/Cliente/GetClienteById?id={id}");
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

        // POST: ClienteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            var apiResponse = await _services.DeleteAsync<ClienteDeleteModel>($"http://localhost:5231/api/Cliente/DeleteCliente?id={id}");

            if (apiResponse.Success)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ModelState.AddModelError(string.Empty, apiResponse.Message);
                return NotFound();
            }
        }
    }
}
