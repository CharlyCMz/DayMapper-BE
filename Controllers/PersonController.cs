using DayMapper_BE.Models;
using DayMapper_BE.Services;
using Microsoft.AspNetCore.Mvc;

namespace DayMapper_BE.Controllers
{
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Get()
        {
            return Ok(_personService.Get());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetOne([FromRoute] Guid id)
        {
            return Ok(await _personService.GetOne(id));
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] Person payload)
        {
            return Ok(await _personService.Save(payload));
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] Person payload)
        {
            return Ok(await _personService.Update(id, payload));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            return Ok(await _personService.Delete(id));
        }
    }
}
