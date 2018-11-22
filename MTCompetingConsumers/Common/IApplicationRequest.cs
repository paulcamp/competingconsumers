using System;
using MassTransit;

namespace Common
{
    public interface IApplicationRequest : CorrelatedBy<Guid>
    {
        // Required by SignalR
        string ClientConnectionId { get; set; }
        
        DateTime TimeStamp { get; set; }
     
        string Name { get; set; }

        ConsoleColor IdentifyingColor { get; set; }

        // any additional (generic) parameters
        string ParamsAsJson { get; set; }
    }
}
