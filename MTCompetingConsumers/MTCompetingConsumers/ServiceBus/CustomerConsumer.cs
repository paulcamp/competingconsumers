using System.Collections.Generic;
using Common;
using MassTransit;
using MTCompetingConsumers.Hubs;

namespace MTCompetingConsumers.ServiceBus
{
    public class CustomerConsumer : Consumes<BaristaReadyMessage>.All
    {
        public CustomerConsumer()
        {
            RecentMessages = new List<string>();
        }

        public static List<string> RecentMessages { get; set; }

        /// Consume is a callback registered as a Masstransit ServiceBus subscriber
        public void Consume(BaristaReadyMessage message)
        {
            string messageSignature = message.OriginalRequest.CorrelationId.ToString();
            if (!RecentMessages.Contains(messageSignature))
            {
                AddMessageSignature(messageSignature);
                
                StaticHub.NotifyResult(message);
                
            }
        }

        private static void AddMessageSignature(string messageSignature)
        {
            if (RecentMessages.Count == 10)
            {
                RecentMessages.RemoveAt(0);
            }

            RecentMessages.Add(messageSignature);
        }
    }
}