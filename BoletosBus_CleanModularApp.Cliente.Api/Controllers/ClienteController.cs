using BoletosBus_CleanModularApp.Cliente.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BoletosBus_CleanModularApp.Cliente.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        public ClienteController(IClienteService clienteService)
        {
            this._clienteService = clienteService;
        }
        // GET: api/<ClienteController>
        [HttpGet("GetClientes")]
        public IActionResult Get()
        {
            var result = _clienteService.GetClientes();
            if (!result.Success) 
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // GET api/<ClienteController>/5
        [HttpGet("GetClienteById")]
        public IActionResult Get(int id)
        {
            var result = _clienteService.GetClienteById(id);
            if (!result.Success) 
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // POST api/<ClienteController>
        [HttpPost("SaveCliente")]
        public IActionResult Post([FromBody] BoletosBus_CleanModularApp.Cliente.Application.Dtos.ClienteSaveDto clienteSaveDto)
        {
            var result = _clienteService.SaveCliente(clienteSaveDto);
            if (!result.Success) 
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // PUT api/<ClienteController>/5
        [HttpPut("UpdateCliente")]
        public IActionResult post(BoletosBus_CleanModularApp.Cliente.Application.Dtos.ClienteUpdateDto clienteUpdateDto)
        {
            var result = _clienteService.UpdateCliente(clienteUpdateDto);
            if (!result.Success) 
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("DeleteCliente")]
        public IActionResult Delete(BoletosBus_CleanModularApp.Cliente.Application.Dtos.ClienteDeleteDto clienteDeleteDto)
        {
            var result = _clienteService.DeleteCliente(clienteDeleteDto);
            if (!result.Success) 
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
