using System;
using Common;
using MassTransit;

namespace MTConsoleBarista
{
    public class BaristaService
    {
        private readonly string _uniqueinstance;

        public BaristaService(string uniqueinstance)
        {
            _uniqueinstance = uniqueinstance;
        }

        public void Start()
        {
            Bus.Initialize(
                sbc =>
                {
                    sbc.UseRabbitMq();
                    var rabbitMqName = "loopback://localhost/barista_service";
                    sbc.ReceiveFrom(rabbitMqName);
                    sbc.SetConcurrentConsumerLimit(4);
                    sbc.SetDefaultRetryLimit(3);

                    ConsoleHelper.WriteLine(rabbitMqName);

                    //NOTE: to achieve competing consumers we use our own unique control bus or none at all
                    var rabbitmqcontrolname = GetUniqueControlQueueName(rabbitMqName, _uniqueinstance);
                    var controlUri = new Uri(rabbitmqcontrolname);
                    sbc.UseControlBus(cb => cb.ReceiveFrom(controlUri));

                    sbc.Subscribe(subs =>
                    {
                        subs.Instance(new BaristaConsumer());
                    });
                });
        }

        public void Stop(string uniqueInstance)
        {

            Bus.Shutdown();

            // now delete the queues we made 
            //ServiceBusHelperFactory.DeleteAllRabbitQueuesUniqueToThisFarmInstance(uniqueInstance);

        }
        
        private static string GetUniqueControlQueueName(string incomingQueueName, string uniqueinstance)
        {
            return string.Format("{0}_{1}_control", incomingQueueName, uniqueinstance);
        }
    }
}
