using DataflowIntegrationTests.Interface;
using Microsoft.AspNetCore.SignalR.Client;

namespace DataflowIntegrationTests.Service
{
    public class HubConnectionService : IHubConnectionService
    {
        private HubConnection _hubConnection;

        public event Action<string> OnMessageReceived;

        public HubConnectionService()
        {
            _hubConnection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5000/syncHub")
                .Build();

            _hubConnection.On<string>("ReceiveMessage", (message) =>
            {
                OnMessageReceived?.Invoke(message);
            });
        }

        public async Task StartAsync()
        {
            await _hubConnection.StartAsync();
        }

        public async Task SendMessageAsync(string message)
        {
            await _hubConnection.InvokeAsync("SendMessage", message);
        }
        public void SimulateMessageReceived(string message)
        {
            OnMessageReceived?.Invoke(message);
        }
    }
}
