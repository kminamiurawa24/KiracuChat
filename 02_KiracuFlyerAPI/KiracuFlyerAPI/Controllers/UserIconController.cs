using KiracuFlyerAPI.Request;
using KiracuFlyerAPI.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace KiracuFlyerAPI.Controllers
{
    [ApiController]
    [Route("user_icons")]
    public class UserIconController : ControllerBase
    {
        private readonly IUserIconService _userIconService;

        public UserIconController(IUserIconService userIconService)
        {
            _userIconService = userIconService;
        }

        [HttpPost]
        public IActionResult CreateUserIcon([FromBody] CreateUserIconRequest request)
        {
            var iconId = _userIconService.CreateUserIcon(request);
            return CreatedAtAction(nameof(GetUserIcon), new { iconId = iconId }, null);
        }

        [HttpGet("{iconId}")]
        public IActionResult GetUserIcon(int iconId)
        {
            var userIcon = _userIconService.GetUserIcon(iconId);
            if (userIcon == null)
            {
                return NotFound();
            }
            return Ok(userIcon);
        }

        [HttpPut("{iconId}")]
        public IActionResult UpdateUserIcon(int iconId, [FromBody] UpdateUserIconRequest request)
        {
            _userIconService.UpdateUserIcon(iconId, request);
            return NoContent();
        }

        [HttpDelete("{iconId}")]
        public IActionResult DeleteUserIcon(int iconId)
        {
            _userIconService.DeleteUserIcon(iconId);
            return NoContent();
        }
    }
}