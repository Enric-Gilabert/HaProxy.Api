using System.Collections.Generic;
using System.Text;

namespace HaProxyApi.Models
{
   

    public interface IHAProxyResponse
    {
        /// <summary>
        /// HAProxy raw return
        /// </summary>
        string Raw { get; }
    }
}
