using System;
using System.Collections.Generic;
using System.Text;

namespace HaProxyApi.Models
{

    public class ShowErrorResponse : IShowErrorResponse
    {
        public string Raw { get; set; }
        public DateTime? CapturedOn { get; set; }
        public long? TotalEvents { get; set; }
    }
}
