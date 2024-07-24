using BoletosBus_CleanModularApp.Bus.Application.Dtos;
using BoletosBus_CleanModularApp.Bus.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BoletosBus_CleanModularApp.Bus.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusController : ControllerBase
    {
        private readonly IBusService _busService;

        public BusController(IBusService busService)
        {
            this._busService = busService;
        }
        // GET: api/<BusController>
        [HttpGet("GetBuses")]
        public IActionResult Get()
        {
            var result = _busService.GetBuses();
            if(!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // GET api/<BusController>/5
        [HttpGet("GetBusById")]
        public IActionResult Get(int id)
        {
            var result = this._busService.GetBusById(id);
            if(!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // POST api/<BusController>
        [HttpPost]
        public IActionResult Post([FromBody] BusSaveDto busSaveDto)
        {
            var result = this._busService.SaveBus(busSaveDto);
            if(!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // PUT api/<BusController>/5
        [HttpPut("UpdateBus")]
        public IActionResult Post(BusUpdateDto busUpdateDto)
        {
            var result = this._busService.UpdateBus(busUpdateDto);
            if(!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // DELETE api/<BusController>/5
        [HttpDelete("DeleteBus")]
        public IActionResult Delete(BusDeleteDto busDeleteDto)
        {
            var result = this._busService.DeleteBus(busDeleteDto);
            if(!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
