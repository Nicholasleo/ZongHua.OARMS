using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZongHua.Models
{
    /// <summary>
    /// 系统UUID
    /// 系统表公有的字段
    /// </summary>
    public class BaseColumn
    {
        public const string UID = "uid";
        public const string RID = "rid";
        public const string FID = "fid";
        public const string CID = "cid";
        public const string MID = "mid";
        public const string PID = "pid";
        public const string CreateTime = "createTime";
        public const string CreatePerson = "createPerson";
        public const string ModifyTime = "modifyTime";
        public const string ModifyPerson = "modifyPerson";
        public const string IsUser = "isUse";
    }
}
