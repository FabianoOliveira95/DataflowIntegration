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

        // Set up SignalR connection
        private async void SetupSignalR()
        {
            // Use o novo cliente de SignalR
            _hubConnection = new HubConnectionBuilder()
                .WithUrl("https://localhost:5000/syncHub")  // Certifique-se de usar o mesmo caminho configurado no servidor
                .Build();

            // Quando receber uma mensagem da Application 2, atualize o textBox2
            _hubConnection.On<string>("ReceiveMessage", (message) =>
            {
                Invoke((Action)(() => textBox2.Text = message));  // Atualiza o textBox2 no thread da UI
            });

            try
            {
                await _hubConnection.StartAsync();  // Inicie a conexão de forma assíncrona
                MessageBox.Show("Conexão estabelecida com o SignalR Hub.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao conectar com o SignalR Hub: {ex.Message}");
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var content = new StringContent($"{{ \"text\": \"{textBox1.Text}\" }}", System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("https://localhost:5000/api/application2", content);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Texto enviado com sucesso!");
            }
            else
            {
                MessageBox.Show($"Erro ao enviar texto: {response.StatusCode}");
            }
        }
    }
}