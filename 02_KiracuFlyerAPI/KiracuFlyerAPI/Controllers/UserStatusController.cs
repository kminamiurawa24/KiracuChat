using KiracuFlyerAPI.Model;
using Microsoft.AspNetCore.Mvc;
using KiracuFlyerAPI.Service.Interface;
using KiracuFlyerAPI.Request;
using KiracuFlyerAPI.Service;

namespace KiracuFlyerAPI.Controllers
{
    [ApiController]
    [Route("user/{userId}/status")]
    public class UserStatusController : ControllerBase
    {
        private readonly IUserStatusService _userStatusService;
        private readonly IStatusService _statusMasterService;

        public UserStatusController(IUserStatusService userStatusService, IStatusService statusMasterService)
        {
            _userStatusService = userStatusService;
            _statusMasterService = statusMasterService;
        }

        [HttpGet]
        public async Task<IActionResult> GetStatus(int userId)
        {
            // ユーザーのステータス情報を取得
            var userStatus = await _userStatusService.GetByUserIdAsync(userId);

            if (userStatus == null)
            {
                return NotFound();
            }

            // ステータスIDに対応するステータス名を取得
            var statusMaster = await _statusMasterService.GetByIdAsync(userStatus.StatusId);

            if (statusMaster == null)
            {
                return NotFound();
            }

            // ステータス情報とステータス名を組み合わせて返却
            var response = new
            {
                UserId = userStatus.UserId,
                StatusId = userStatus.StatusId,
                StatusName = statusMaster.Status,
                CustomMessage = userStatus.CustomMessage,
                UpdatedAt = userStatus.UpdatedAt
            };

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStatus(int userId, UpdateUserStatusRequest request)
        {
            // ステータスIDが有効かどうかを確認
            var statusMaster = await _statusMasterService.GetByIdAsync(request.StatusId);

            if (statusMaster == null)
            {
                return BadRequest("Invalid status ID.");
            }

            // ユーザーのステータス情報を更新
            var userStatus = new UserStatus
            {
                UserId = userId,
                StatusId = request.StatusId,
                CustomMessage = request.CustomMessage,
                UpdatedAt = DateTime.UtcNow
            };

            await _userStatusService.UpdateUserStatusAsync(userStatus);

            return NoContent();
        }
    }
}
