namespace Application2.Hub
{
    public class SyncHub
    {
        /// <summary>
        /// Send the message to all connected clients
        /// </summary>
        /// <param name="message">Message content</param>
        public void SendMessage(string message)
        {
            Clients.All.ReceiveMessage(message);
        }
    }
}
