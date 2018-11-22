using System;

namespace Common
{
    [Serializable]
    public class BaristaRequest : IApplicationRequest
    {
        public BaristaRequest()
        {
        }

        public BaristaRequest(IApplicationRequest applicationRequest)
        {
            CorrelationId = applicationRequest.CorrelationId;
            ClientConnectionId = applicationRequest.ClientConnectionId;
            IdentifyingColor = applicationRequest.IdentifyingColor;
            Name = applicationRequest.Name;
            TimeStamp = applicationRequest.TimeStamp;
            ParamsAsJson = applicationRequest.ParamsAsJson;
        }

        public Guid CorrelationId { get; set; }

        public string ClientConnectionId { get; set; }
        
        public string Name { get; set; }

        public string ParamsAsJson { get; set; }

        public DateTime TimeStamp { get; set; }

        public ConsoleColor IdentifyingColor { get; set; }
    }
}