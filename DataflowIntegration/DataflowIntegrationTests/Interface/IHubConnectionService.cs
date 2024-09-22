using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataflowIntegrationTests.Interface
{
    public interface IHubConnectionService
    {
        event Action<string> OnMessageReceived;
        Task StartAsync();
        Task SendMessageAsync(string message);
        void SimulateMessageReceived(string message);
    }
}
