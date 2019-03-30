using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZongHua.Models
{
    public class BaseOrderEnt
    {/// <summary>
     /// 主题编号
     /// </summary>
        public string SubjectCode { get; set; }
        /// <summary>
        /// 用户编号
        /// </summary>
        public string UserCode { get; set; }
        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 用户类型
        /// </summary>
        public string UserType { get; set; }
        /// <summary>
        /// 登录设备MAC
        /// </summary>
        public string DeviceMac { get; set; }
        /// <summary>
        /// 登录设备类型
        /// </summary>
        public string AppType { get; set; }
        /// <summary>
        /// APP版本号
        /// </summary>
        public string AppVersion { get; set; }
    }
}
