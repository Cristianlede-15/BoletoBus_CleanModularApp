using BoletosBus_CleanModularApp.Asiento.Application.Dtos;
using BoletosBus_CleanModularApp.Asiento.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BoletosBus_CleanModularApp.Asiento.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsientoController : ControllerBase
    {
        private readonly IAsientoService? _asientoService;
        public AsientoController(IAsientoService asientoService)
        {
            this._asientoService = asientoService;
        }
        // GET: api/<AsientoController>
        [HttpGet("GetAsientos")]
        public IActionResult Get()
        {
            var result = this._asientoService?.GetAsientos();
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // GET api/<AsientoController>/5
        [HttpGet("GetAsientoById")]
        public IActionResult Get(int id)
        {
            var result = this._asientoService?.GetAsientoById(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // POST api/<AsientoController>
        [HttpPost("SaveAsiento")]
        public IActionResult Post([FromBody] AsientoSaveDto asientoSaveDto)
        {
            var result = this._asientoService?.SaveAsiento(asientoSaveDto);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // PUT api/<AsientoController>/5
        [HttpPut("UpdateAsiento")]
        public IActionResult post(AsientoUpdateDto asientoUpdateDto)
        {
            var result = this._asientoService?.UpdateAsiento(asientoUpdateDto);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // DELETE api/<AsientoController>/5
        [HttpDelete("DeleteAsiento")]
        public IActionResult Delete(AsientoDeleteDto asientoDeleteDto)
        {
            var result = this._asientoService?.DeleteAsiento(asientoDeleteDto);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
