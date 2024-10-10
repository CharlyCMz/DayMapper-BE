using DayMapper_BE.Models;
using DayMapper_BE.Services;
using Microsoft.AspNetCore.Mvc;

namespace DayMapper_BE.Controllers
{
    [Route("[controller]")]
    public class AddressController : ControllerBase
    {
        IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Get()
        {
            return Ok(_addressService.Get());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetOne([FromRoute] Guid id)
        {
            return Ok(await _addressService.GetOne(id));
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] Address payload)
        {
            return Ok(await _addressService.Save(payload));
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] Address payload)
        {
            return Ok(await _addressService.Update(id, payload));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id) 
        {
            return Ok(await _addressService.Delete(id));
        }
    }
}
