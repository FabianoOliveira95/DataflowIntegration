using Microsoft.AspNetCore.SignalR;

namespace Application2
{
    public class SyncHub : Hub
    {
        /// <summary>
        /// Send message to all connected clients
        /// </summary>
        /// <param name="message">Message content</param>
        /// <returns></returns>
        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}
