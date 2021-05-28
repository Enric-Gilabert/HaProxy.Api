using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HaProxyApi.Models
{
    public class StateInfo
    {

        [Column("pxname")]
        public  string Name { get; set; }
        [Column("svname")]
        public string ServerName { get; set; }
        [Column("qcur")]
        public string QueueCur { get; set; }
        [Column("qmax")]
        public string QueueMax { get; set; }
        [Column("scur")]
        public string SesionCur { get; set; }
        [Column("smax")]
        public string SesionMax { get; set; }
        [Column("slim")]
        public string SesionLimit { get; set; }
        [Column("stot")]
        public string SesionTot { get; set; }
        [Column("bin")]
        public string BitIn { get; set; }
        [Column("bout")]
        public string BitOut { get; set; }
        [Column("dreq")]
        public string DeniedReq { get; set; }
        [Column("dresp")]
        public string DeniedResp { get; set; }
        [Column("ereq")]
        public string ErrorReq { get; set; }
        [Column("econ")]
        public string ErrorCon { get; set; }
        [Column("eresp")]
        public string ErrorResp { get; set; }
        [Column("wretr")]
        public string WarningRetr { get; set; }
        [Column("wredis")]
        public string WarningRedis { get; set; }
        [Column("status")]
        public string Status { get; set; }
        [Column("weight")]
        public string Weight { get; set; }
        [Column("act")]
        public string Act { get; set; }
        [Column("bck")]
        public string Bck { get; set; }
        [Column("chkfail")]
        public string ChkFail { get; set; }
        [Column("chkdown")]
        public string ChkDown { get; set; }
        [Column("lastchg")]
        public string LastChg { get; set; }
        [Column("downtime")]
        public string DonwTime { get; set; }
        [Column("qlimit")]
        public string QLimit { get; set; }
        [Column("pid")]
        public string Pid { get; set; }
        [Column("iid")]
        public string Iid { get; set; }
        [Column("sid")]
        public string Sid { get; set; }
        [Column("throttle")]
        public string Throttle { get; set; }
        [Column("lbtot")]
        public string Lbtot { get; set; }
        [Column("tracked")]
        public string Tracked { get; set; }
        [Column("type")]
        public string Type { get; set; }
        [Column("rate")]
        public string Rate { get; set; }
        [Column("rate_lim")]
        public string RateLim { get; set; }
        [Column("rate_max")]
        public string RateMax { get; set; }
        [Column("check_status")]
        public string CheckStatus { get; set; }
        [Column("check_code")]
        public string CheckCode { get; set; }
        [Column("check_duration")]
        public string CheckDuration { get; set; }
        [Column("hrsp_1xx")]
        public string Hrsp1xx { get; set; }
        [Column("hrsp_2xx")]
        public string Hrsp2xx { get; set; }
        [Column("hrsp_3xx")]
        public string Hrsp3xx { get; set; }
        [Column("hrsp_4xx")]
        public string Hrsp4xx { get; set; }
        [Column("hrsp_5xx")]
        public string Hrsp5xx { get; set; }
        [Column("hrsp_other")]
        public string HrspOther { get; set; }
        [Column("hanafail")]
        public string HanaFail { get; set; }
        [Column("req_rate")]
        public string ReqRate { get; set; }
        [Column("req_rate_max")]
        public string ReqRateMax { get; set; }
        [Column("req_tot")]
        public string ReqTot { get; set; }
        [Column("cli_abrt")]
        public string CliAbrt { get; set; }
        [Column("srv_abrt")]
        public string SrvAbrt{ get; set; }
        [Column("comp_in")]
        public string CompIn { get; set; }
        [Column("comp_out")]
        public string CompOut { get; set; }
        [Column("comp_byp")]
        public string CompByp { get; set; }
        [Column("comp_rsp")]
        public string CompRsp { get; set; }
        [Column("lastsess")]
        public string LastSess { get; set; }
        [Column("last_chk")]
        public string LastChk { get; set; }
        [Column("last_agt")]
        public string LastAgt{ get; set; }
        [Column("qtime")]
        public string QTime { get; set; }
        [Column("ctime")]
        public string CTime { get; set; }
        [Column("rtime")]
        public string RTime { get; set; }
        [Column("ttime")]
        public string TTime{ get; set; }
        [Column("agent_status")]
        public string AgentStatus{ get; set; }
        [Column("agent_code")]
        public string AgentCode{ get; set; }
        [Column("agent_duration")]
        public string AgentDuration { get; set; }
        [Column("check_desc")]
        public string CheckDesc { get; set; }
        [Column("agent_desc")]
        public string AgentDesc { get; set; }
        [Column("check_rise")]
        public string CheckRise { get; set; }
        [Column("check_fall")]
        public string CheckFall{ get; set; }
        [Column("check_health")]
        public string CheckHealth{ get; set; }
        [Column("agent_rise")]
        public string AgentRise { get; set; }
        [Column("agent_fall")]
        public string AgentFall { get; set; }
        [Column("agent_health")]
        public string AgentHealth{ get; set; }
        [Column("addr")]
        public string Addr { get; set; }
        [Column("cookie")]
        public string Cookie { get; set; }
        [Column("mode")]
        public string mode { get; set; }
        [Column("algo")]
        public string algo { get; set; }
        [Column("conn_rate")]
        public string connRate { get; set; }
        [Column("conn_rate_max")]
        public string connRateMax { get; set; }
        [Column("conn_tot")]
        public string connTotal { get; set; }
        [Column("intercepted")]
        public string intercepted { get; set; }
        [Column("dcon")]
        public string dcon { get; set; }
        [Column("dses")]
        public string deses { get; set; }
    }
}