using System;
using System.Threading;
using Common;
using MassTransit;

namespace MTConsoleBarista
{
    public class BaristaConsumer : Consumes<BaristaRequest>.All
    {
        public void Consume(BaristaRequest message)
        {
            var msg = string.Format("{0},{1}", message.Name, message.ParamsAsJson);
            var prepmsg = string.Format("Preparing Drink {0}.....", message.ParamsAsJson);
            var completemsg = string.Format("Finished Drink {0}", message.ParamsAsJson);

            ConsoleHelper.WriteLine(msg, message.IdentifyingColor);
            ConsoleHelper.WriteLine(prepmsg, message.IdentifyingColor);
            Thread.Sleep(15000);
            ConsoleHelper.WriteLine(completemsg, message.IdentifyingColor);

            var nextMessage = new BaristaReadyMessage()
            {
                OriginalRequest = message,
                CorrelationId = message.CorrelationId,
                CompletedDateTime = DateTime.UtcNow,
                JsonResults = "Your " + message.ParamsAsJson + " is ready!"
            };
            
            Bus.Instance.Publish(nextMessage);
        }
    }
}
