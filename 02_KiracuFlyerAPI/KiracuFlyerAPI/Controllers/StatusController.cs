using KiracuFlyerAPI.Model;
using KiracuFlyerAPI.Service;
using KiracuFlyerAPI.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace KiracuFlyerAPI.Controllers
{
    [ApiController]
    [Route("status")]
    public class StatusController : ControllerBase
    {
        private readonly IStatusService _statusMasterService;

        public StatusController(IStatusService statusMasterService)
        {
            _statusMasterService = statusMasterService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStatuses()
        {
            // ステータス情報を全件取得
            var statuses = await _statusMasterService.GetAllAsync();

            return Ok(statuses);
        }
    }
}