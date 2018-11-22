using Common;
using MassTransit;

namespace MTConsoleCashier
{
    public class CashierService
    {
        public void Start()
        {
            Bus.Initialize(
                sbc =>
                {
                    sbc.UseRabbitMq();
                    var rabbitMqName = "rabbitmq://localhost/cashier_service";
                    sbc.ReceiveFrom(rabbitMqName);
                    sbc.SetConcurrentConsumerLimit(1);
                    sbc.SetDefaultRetryLimit(3);
                    ConsoleHelper.WriteLine(rabbitMqName);
                    sbc.UseControlBus();
                    sbc.Subscribe(subs =>
                    {
                        subs.Instance(new CashierConsumer());
                    });

                });
                
        }

        public void Stop()
        {
            Bus.Shutdown();
        }
    }
}
