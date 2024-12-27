using KiracuFlyerAPI.Request;
using KiracuFlyerAPI.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace KiracuFlyerAPI.Controllers
{
    [ApiController]
    [Route("channel_icon_masters")]
    public class ChannelIconMasterController : ControllerBase
    {
        private readonly IChannelIconMasterService _channelIconMasterService;

        public ChannelIconMasterController(IChannelIconMasterService channelIconMasterService)
        {
            _channelIconMasterService = channelIconMasterService;
        }

        [HttpPost]
        public IActionResult CreateChannelIconMaster([FromBody] CreateChannelIconMasterRequest request)
        {
            var iconId = _channelIconMasterService.CreateChannelIconMaster(request);
            return CreatedAtAction(nameof(GetChannelIconMaster), new { iconId = iconId }, null);
        }

        [HttpGet("{iconId}")]
        public IActionResult GetChannelIconMaster(int iconId)
        {
            var channelIconMaster = _channelIconMasterService.GetChannelIconMaster(iconId);
            if (channelIconMaster == null)
            {
                return NotFound();
            }
            return Ok(channelIconMaster);
        }

        [HttpPut("{iconId}")]
        public IActionResult UpdateChannelIconMaster(int iconId, [FromBody] UpdateChannelIconMasterRequest request)
        {
            _channelIconMasterService.UpdateChannelIconMaster(iconId, request);
            return NoContent();
        }

        [HttpDelete("{iconId}")]
        public IActionResult DeleteChannelIconMaster(int iconId)
        {
            _channelIconMasterService.DeleteChannelIconMaster(iconId);
            return NoContent();
        }
    }
}