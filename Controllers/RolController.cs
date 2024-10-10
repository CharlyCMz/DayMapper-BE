using DayMapper_BE.Models;
using DayMapper_BE.Services;
using Microsoft.AspNetCore.Mvc;

namespace DayMapper_BE.Controllers
{
    [Route("[controller]")]
    public class RolController : ControllerBase
    {
        IRolService _rolService;

        public RolController(IRolService rolService)
        {
            _rolService = rolService;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Get()
        {
            return Ok(_rolService.Get());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetOne([FromRoute] int id)
        {
            return Ok(await _rolService.GetOne(id));
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] Rol payload)
        {
            return Ok(await _rolService.Save(payload));
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] Rol payload)
        {
            return Ok(await _rolService.Update(id, payload));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return Ok(await _rolService.Delete(id));
        }
    }
}
