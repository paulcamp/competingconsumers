using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using MassTransit;

namespace MTCompetingConsumers.ServiceBus
{
    public static class WebServiceBusHelper
    {

        public static void InitServiceBus()
        {
            // singleton bus for the UI - revisit this if more queues are needed on the UI.
            Bus.Initialize(sbc =>
            {
                sbc.UseRabbitMq();
                sbc.ReceiveFrom("loopback://localhost/customer");
                sbc.UseControlBus();
                sbc.UseXmlSerializer();
                sbc.EnableRemoteIntrospection();
                sbc.SetConcurrentConsumerLimit(1);
                sbc.SetDefaultRetryLimit(3);
            });

            // instantiate a  consumer
            Bus.Instance.SubscribeInstance(new CustomerConsumer());
        }

        public static void KillServiceBus()
        {
            Bus.Instance.Dispose();
            Bus.Shutdown();
        }


        /// <summary>
        /// Method to send any message to the Service Bus
        /// </summary>
        /// <param name="clientConnectionId">For Signal R to enable it to identify each client</param>
        /// <param name="name">Friendly display name, e.g. CashierRequest</param>
        /// <param name="requestType"></param>
        /// <param name="additionalOptionsAsJson">Anything additional that the farm requires to process the message, e.g. ReportTemplateId, perhaps Report Type</param>
        /// <param name="clientGroupName">HttpContext.Current.User.Identity.Name</param>
        /// <returns></returns>
        public static IApplicationRequest Send(string clientConnectionId, string name, RequestType requestType, string additionalOptionsAsJson, string clientGroupName = "unknown")
        {
            var transactionId = Guid.NewGuid();
            
            switch (requestType)
            {
                case RequestType.Cashier:
                    
                        // log request made in template table
                        return
                            PublishMessageToServiceBus(
                                new CashierRequest {/*RequestType = requestType,*/ CorrelationId = transactionId}, name,
                                 clientConnectionId, additionalOptionsAsJson, clientGroupName);
                    

                case RequestType.Barista:
                        return
                            PublishMessageToServiceBus(
                                new BaristaRequest {/*RequestType = requestType,*/ CorrelationId = transactionId}, name,
                                 clientConnectionId, additionalOptionsAsJson, clientGroupName);
            }

            throw new Exception("Unknown request from client");
        }
        
        private static T PublishMessageToServiceBus<T>(T message, string name, string clientConnectionId, string paramsAsJson, string clientGroupName) where T : IApplicationRequest
        {
            message.ClientConnectionId = clientConnectionId;
            //message.ClientConnectionGroup = clientGroupName;
            message.Name = name;
            message.TimeStamp = DateTime.UtcNow;
            message.ParamsAsJson = paramsAsJson;
            message.IdentifyingColor = GetGoodConsoleColor();
            Bus.Instance.Publish(message, x => x.SetResponseAddress(Bus.Instance.Endpoint.Address.Uri));
            return message;
        }

        private static ConsoleColor GetGoodConsoleColor()
        {
            int[] goodConsoleColours = { 10, 11, 12, 13, 14, 15 };
            //Green = 10,Cyan = 11,Red = 12,Magenta = 13,Yellow = 14, White = 15

            ConsoleColor color;

            do
            {
                int randomNumber = new Random().Next();
                color = (ConsoleColor)goodConsoleColours[randomNumber % goodConsoleColours.Length];

            } while (RecentColors.Contains(color));
            
            AddColorUsage(color);

            return color;
        }

        private static List<ConsoleColor> RecentColors = new List<ConsoleColor>();

        private static void AddColorUsage(ConsoleColor colorUsed)
        {
            if (RecentColors.Count == 5)
            {
                RecentColors.RemoveAt(0);
            }

            RecentColors.Add(colorUsed);
        }

    }
}