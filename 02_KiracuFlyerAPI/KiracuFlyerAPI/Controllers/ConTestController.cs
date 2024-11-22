using Microsoft.AspNetCore.Mvc;

namespace KiracuFlyerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConTestController : ControllerBase
    {
        /// <summary>
        /// コネクションをテストする、GETなエンドポイント
        /// エンドポイント/ConTest/ping
        /// </summary>
        /// <returns></returns>
        [HttpGet("ping")]
        public IActionResult Ping()
        {
            return Ok(new { message = "Pong!", timestamp = DateTime.UtcNow });
        }
    }
}
