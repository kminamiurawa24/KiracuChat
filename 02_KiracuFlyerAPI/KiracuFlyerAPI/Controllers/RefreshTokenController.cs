using KiracuFlyerAPI.Model;
using KiracuFlyerAPI.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace KiracuFlyerAPI.Controllers
{
    [ApiController]
    [Route("refresh_tokens")]
    public class RefreshTokenController : Controller
    {
        private readonly IRefreshTokenService _refreshTokenService;

        public RefreshTokenController(IRefreshTokenService refreshTokenService)
        {
            _refreshTokenService = refreshTokenService;
        }

        [HttpPost]
        public IActionResult CreateRefreshToken([FromBody] RefreshToken refreshToken)
        {
            _refreshTokenService.CreateRefreshToken(refreshToken);
            return CreatedAtAction(nameof(GetRefreshTokenByUserId), new { userId = refreshToken.UserId }, null);
        }

        [HttpGet("{userId}")]
        public IActionResult GetRefreshTokenByUserId(int userId)
        {
            var refreshToken = _refreshTokenService.GetRefreshTokenByUserId(userId);
            if (refreshToken == null)
            {
                return NotFound();
            }
            return Ok(refreshToken);
        }

        [HttpPut]
        public IActionResult UpdateRefreshToken([FromBody] RefreshToken refreshToken)
        {
            _refreshTokenService.UpdateRefreshToken(refreshToken);
            return NoContent();
        }

        [HttpDelete("{userId}")]
        public IActionResult DeleteRefreshToken(int userId)
        {
            _refreshTokenService.DeleteRefreshToken(userId);
            return NoContent();
        }
    }
}
