using System;

namespace HaProxyApi.Models
{
    public interface IShowErrorResponse : IHAProxyResponse
    {
        DateTime? CapturedOn { get; }

        long? TotalEvents { get; }
    }
}