using Microsoft.AspNetCore.SignalR.Client;

namespace Application1
{
    public partial class Application1 : Form
    {
        private HttpClient _httpClient;
        private HubConnection? _hubConnection;

        public Application1()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
            SetupSignalR();
        }

        public Application1(HttpClient httpClient)
        {
            InitializeComponent();
            _httpClient = httpClient;
        }

        /// <summary>
        /// Setup SignalR connection
        /// </summary>
        private async void SetupSignalR()
        {
            _hubConnection = new HubConnectionBuilder()
                .WithUrl("https://localhost:5000/syncHub")
                .Build();

            _hubConnection.On<string>("ReceiveMessage", (message) =>
            {
                Invoke((Action)(() => textBox2.Text = message));
            });

            try
            {
                await _hubConnection.StartAsync();
                MessageBox.Show("Connection established with SignalR Hub.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error when trying to connect with SignalR Hub: {ex.Message}");
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await SendText(textBox1.Text);
        }

        /// <summary>
        /// Prepares the content and send by API post
        /// </summary>
        /// <param name="text">Text that will be send</param>
        /// <returns></returns>
        public async Task SendText(string text)
        {
            var content = new StringContent($"{{ \"text\": \"{text}\" }}", System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("https://localhost:5000/api/application2", content);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Message sent successfully!");
            }
            else
            {
                MessageBox.Show($"Error when trying to send text: {response.StatusCode}");
            }
        }
    }
}