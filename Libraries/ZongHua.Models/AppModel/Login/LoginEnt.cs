using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZongHua.Models
{
    public class LoginEnt : BaseEnt
    {
        /// <summary>
        /// 注册信息
        /// </summary>
        public string RegMessage { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 移动端相机禁用
        /// </summary>
        public bool DisableCamera { get; set; }
        /// <summary>
        /// 主题列表
        /// </summary>
        public List<SubjectEnt> SubjectLists { get; set; }
    }
}
