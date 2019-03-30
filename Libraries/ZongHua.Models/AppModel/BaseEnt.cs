using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZongHua.Models
{
    public class BaseEnt
    {
        [DefaultValue(MsgFlg.FailMessage)]
        public MsgFlg ResultFlg { get; set; }
        [DefaultValue("")]
        public string ResultMsg { get; set; }
    }

    public enum MsgFlg
    {
        /// <summary>
        /// 返回失败，强制提示信息showConfirm
        /// </summary>
        FailConfirm = -2,
        /// <summary>
        /// 返回失败，提示信息showLoding
        /// </summary>
        FailMessage = -1,
        /// <summary>
        /// 返回成功，提示信息showLoding
        /// </summary>
        Success = 0,
        /// <summary>
        /// 返回成功，强制提示
        /// </summary>
        SuccessMessage = 1,
        /// <summary>
        /// 返回成功，强制提示确认返回
        /// </summary>
        SuccessConfirm = 2
    }
}
