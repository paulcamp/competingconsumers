using System;

namespace Common
{
    [Serializable]
    public class BaristaReadyMessage : IApplicationResponse
    {
        public Guid CorrelationId { get; set; }

        public double ResultsCount { get; set; }

        public DateTime CompletedDateTime { get; set; }

        public IApplicationRequest OriginalRequest { get; set; }

        public string JsonResults { get; set; }
    }
}