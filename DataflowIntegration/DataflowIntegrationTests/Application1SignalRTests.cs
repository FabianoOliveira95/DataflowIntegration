using DataflowIntegrationTests.Interface;
using Moq;

namespace DataflowIntegrationTests
{
    public class Application1SignalRTests
    {
        [Fact]
        public async Task ReceiveMessageFromHubTest()
        {
            // Arrange
            var mockHubConnectionService = new Mock<IHubConnectionService>();
            string receivedMessage = string.Empty;

            // Ação que armazena a mensagem recebida
            mockHubConnectionService.Object.OnMessageReceived += (message) =>
            {
                receivedMessage = message;
            };

            // Simular a recepção de uma mensagem chamando o evento diretamente
            mockHubConnectionService.Raise(m => m.OnMessageReceived += null, "Hello from Test");

            // Act
            await mockHubConnectionService.Object.StartAsync(); // Se necessário

            // Assert
            Assert.Equal("Hello from Test", receivedMessage);
        }
    }
}
