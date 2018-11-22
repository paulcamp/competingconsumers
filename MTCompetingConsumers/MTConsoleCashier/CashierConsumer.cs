using System.Threading;
using Common;
using MassTransit;

namespace MTConsoleCashier
{
    class CashierConsumer : Consumes<CashierRequest>.All
    {
        public void Consume(CashierRequest message)
        {
            var msg = string.Format("{0},{1}", message.Name, message.ParamsAsJson);
            var prepmsg = string.Format("Taking Payment for {0}.....", message.ParamsAsJson);
            var completemsg = string.Format("Payment finished for {0}", message.ParamsAsJson);

            ConsoleHelper.WriteLine(msg, message.IdentifyingColor);
            ConsoleHelper.WriteLine(prepmsg, message.IdentifyingColor);
            Thread.Sleep(5000);
            ConsoleHelper.WriteLine(completemsg, message.IdentifyingColor);
            
            var nextMessage = new BaristaRequest(message);
            Bus.Instance.Publish(nextMessage);
        }
    }
}
