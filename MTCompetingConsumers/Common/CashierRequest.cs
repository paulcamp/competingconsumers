using System;

namespace Common
{
    [Serializable]
    public class CashierRequest : IApplicationRequest
    {
        public CashierRequest()
        {
        }

        public CashierRequest(IApplicationRequest applicationRequest)
        {
            CorrelationId = applicationRequest.CorrelationId;
            ClientConnectionId = applicationRequest.ClientConnectionId;
            Name = applicationRequest.Name;
            ParamsAsJson = applicationRequest.ParamsAsJson;
            TimeStamp = applicationRequest.TimeStamp;
            IdentifyingColor = applicationRequest.IdentifyingColor;
        }

        public Guid CorrelationId { get; set; }

        public string ClientConnectionId { get; set; }

        public string Name { get; set; }

        public string ParamsAsJson { get; set; }

        public DateTime TimeStamp { get; set; }

        public ConsoleColor IdentifyingColor { get; set; }
    }
}