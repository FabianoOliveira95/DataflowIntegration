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

            mockHubConnectionService.Object.OnMessageReceived += (message) =>
            {
                receivedMessage = message;
            };

            mockHubConnectionService.Raise(m => m.OnMessageReceived += null, "Hello from Test");

            // Act
            await mockHubConnectionService.Object.StartAsync();

            // Assert
            Assert.Equal("Hello from Test", receivedMessage);
        }
    }
}
