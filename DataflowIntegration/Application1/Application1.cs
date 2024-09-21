using Microsoft.AspNet.SignalR.Client;

namespace Application1
{
    public partial class Application1 : Form
    {
        private HttpClient _httpClient;
        private IHubProxy? _hubProxy;
        private HubConnection? _hubConnection;

        public Application1()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
            SetupSignalR();
        }

        // Set up SignalR connection
        private void SetupSignalR()
        {
            _hubConnection = new HubConnection("http://localhost:5000/signalr");
            _hubProxy = _hubConnection.CreateHubProxy("SyncHub");

            // When receiving a message from Application 2, display in outputTextBox
            _hubProxy.On<string>("ReceiveMessage", message =>
            {
                Invoke((Action)(() => textBox2.Text = message));
            });

            _hubConnection.Start().Wait();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var content = new StringContent($"{{ \"text\": \"{textBox1.Text}\" }}", System.Text.Encoding.UTF8, "application/json");
            await _httpClient.PostAsync("http://localhost:5000/api/sync", content);
        }
    }
}