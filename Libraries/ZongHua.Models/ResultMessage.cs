using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZongHua.Models
{
    public class ResultMessage
    {
        [DefaultValue(false)]
        public bool ResultFlg { get; set; }

        public string ResultMsg { get; set; }
    }
}
