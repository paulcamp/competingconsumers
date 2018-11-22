using System;
using System.Configuration;

namespace MTCompetingConsumers.ServiceBus
{
    public static class ConfigHelper
    {
        public static string WebServiceBusQueue
        {
            get
            {
                return ConfigurationManager.AppSettings["WebServiceBusQueue"];
            }
        }

        public static int WebServiceBusRetries
        {
            get
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings["WebServiceBusRetries"]);
            }
        }

        public static int WebBusConcurrency
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings["WebBusConcurrency"]); }
        }
    }
}