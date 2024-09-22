using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Application2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Application2Controller : ControllerBase
    {
        private readonly IHubContext<SyncHub> _hubContext;

        public Application2Controller(IHubContext<SyncHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost]
        public async Task<IActionResult> SyncText([FromBody] SyncTextModel model)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", model.Text);
            return Ok();
        }
    }

    public class SyncTextModel
    {
        public string? Text { get; set; }
    }
}
