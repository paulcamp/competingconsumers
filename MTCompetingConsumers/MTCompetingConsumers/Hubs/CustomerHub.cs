using Common;
using Microsoft.AspNet.SignalR;
using MTCompetingConsumers.ServiceBus;

namespace MTCompetingConsumers.Hubs
{
    public class CustomerHub : Hub
    {
        public void Send(string message)
        {
            //string user = Context.User.Identity.Name; //if using auth
            
            //NOTE: message contains the coffee order...
            WebServiceBusHelper.Send(Context.ConnectionId, "Customer Request", RequestType.Cashier, message);
        }


        public void BulkSend()
        {
            WebServiceBusHelper.Send(Context.ConnectionId, "Customer Request", RequestType.Cashier, "coffee");
            WebServiceBusHelper.Send(Context.ConnectionId, "Customer Request", RequestType.Cashier, "espresso");
            WebServiceBusHelper.Send(Context.ConnectionId, "Customer Request", RequestType.Cashier, "latte");
            WebServiceBusHelper.Send(Context.ConnectionId, "Customer Request", RequestType.Cashier, "mocha");
            WebServiceBusHelper.Send(Context.ConnectionId, "Customer Request", RequestType.Cashier, "macchiato");
            WebServiceBusHelper.Send(Context.ConnectionId, "Customer Request", RequestType.Cashier, "americano");
            WebServiceBusHelper.Send(Context.ConnectionId, "Customer Request", RequestType.Cashier, "decaffinato");
        }
    }
}