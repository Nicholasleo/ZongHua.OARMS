using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZongHua.Models
{
    public class SubjectEnt
    {
        /// <summary>
        /// 主题编号
        /// </summary>
        public string SubjectCode { get; set; }
        /// <summary>
        /// 主题名称
        /// </summary>
        public string SubjectName { get; set; }
        /// <summary>
        /// 主题类型
        /// </summary>
        public string SubjectType { get; set; }
        /// <summary>
        /// 系统自动分配服务URL，默认为手动配置URL
        /// </summary>
        public string GlobalUrl { get; set; }
    }
}
