using System;
using System.Collections.Generic;
using System.Text;

namespace HaProxyApi.Models
{


    public enum ChkResult
    {
        CHK_RES_UNKNOWN = 0,
        CHK_RES_NEUTRAL,
        CHK_RES_FAILED,
        CHK_RES_PASSED,
        CHK_RES_CONDPASS,
    };

    public enum ChkSt
    {
        CHK_ST_INPROGRESS = 0x0001,
        CHK_ST_CONFIGURED = 0x0002,
        CHK_ST_ENABLED = 0x0004,
        CHK_ST_PAUSED = 0x0008,
        CHK_ST_AGENT = 0x0010
    }


    public enum SrvAdmin
    {
        SRV_ADMF_FMAINT = 0x01,
        SRV_ADMF_IMAINT = 0x02,
        SRV_ADMF_MAINT = 0x03,
        SRV_ADMF_CMAINT = 0x04,
        SRV_ADMF_FDRAIN = 0x08,
        SRV_ADMF_IDRAIN = 0x10,
        SRV_ADMF_DRAIN = 0x18,
    };


    public enum SrvState
    {
        SRV_ST_STOPPED = 0,
        SRV_ST_STARTING,
        SRV_ST_RUNNING,
        SRV_ST_STOPPING,
    };


}
