using System;
using MassTransit;


namespace Common
{
    public interface IApplicationResponse : CorrelatedBy<Guid>
    {
        DateTime CompletedDateTime { get; set; }

        IApplicationRequest OriginalRequest { get; set; }

        double ResultsCount { get; set; }

        string JsonResults { get; set; }
    }
}