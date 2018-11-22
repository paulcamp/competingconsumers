using Common;
using Microsoft.AspNet.SignalR;

namespace MTCompetingConsumers.Hubs
{
    public class StaticHub
    {
        public static void NotifyResult(BaristaReadyMessage message)
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<CustomerHub>();
            context.Clients.Client(message.OriginalRequest.ClientConnectionId).broadcastMessage(message.JsonResults);
        }
    }
}