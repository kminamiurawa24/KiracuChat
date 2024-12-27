using KiracuFlyerAPI.Model;
using KiracuFlyerAPI.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace KiracuFlyerAPI.Controllers
{
    [ApiController]
    [Route("user_profiles")]
    public class UserProfileController : ControllerBase
    {
        private readonly IUserProfileService _userProfileService;

        public UserProfileController(IUserProfileService userProfileService)
        {
            _userProfileService = userProfileService;
        }

        [HttpPost]
        public IActionResult CreateUserProfile([FromBody] UserProfile userProfile)
        {
            var userId = _userProfileService.CreateUserProfile(userProfile);
            return CreatedAtAction(nameof(GetUserProfile), new { userId = userId }, null);
        }

        [HttpGet("{userId}")]
        public IActionResult GetUserProfile(int userId)
        {
            var userProfile = _userProfileService.GetUserProfile(userId);
            if (userProfile == null)
            {
                return NotFound();
            }
            return Ok(userProfile);
        }

        [HttpPut]
        public IActionResult UpdateUserProfile([FromBody] UserProfile userProfile)
        {
            _userProfileService.UpdateUserProfile(userProfile);
            return NoContent();
        }

        [HttpDelete("{userId}")]
        public IActionResult DeleteUserProfile(int userId)
        {
            _userProfileService.DeleteUserProfile(userId);
            return NoContent();
        }
    }
}
