using DayMapper_BE.Models;
using DayMapper_BE.Services;
using Microsoft.AspNetCore.Mvc;

namespace DayMapper_BE.Controllers
{
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Get()
        {
            return Ok(_userService.Get());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetOne([FromRoute] Guid id)
        {
            return Ok(await _userService.GetOne(id));
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] User payload)
        {
            return Ok(await _userService.Save(payload));
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] User payload)
        {
            return Ok(await _userService.Update(id, payload));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            return Ok(await _userService.Delete(id));
        }
    }
}
