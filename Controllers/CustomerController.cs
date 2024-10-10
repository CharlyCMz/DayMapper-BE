using DayMapper_BE.Models;
using DayMapper_BE.Services;
using Microsoft.AspNetCore.Mvc;

namespace DayMapper_BE.Controllers
{
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Get()
        {
            return Ok(_customerService.Get());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetOne([FromRoute] Guid id)
        {
            return Ok(await _customerService.GetOne(id));
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] Customer payload)
        {
            return Ok(await _customerService.Save(payload));
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] Customer payload)
        {
            return Ok(await _customerService.Update(id, payload));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            return Ok(await _customerService.Delete(id));
        }
    }
}
