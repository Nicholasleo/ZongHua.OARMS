using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZongHua.Models
{
    public class OrderJsonEnt : BaseOrderEnt
    {
        /// <summary>
        /// 主题类型
        /// </summary>
        public string SubjectType { get; set; }
        /// <summary>
        /// 店铺编号
        /// </summary>
        public string ClientCodes { get; set; }
        
    }
}
