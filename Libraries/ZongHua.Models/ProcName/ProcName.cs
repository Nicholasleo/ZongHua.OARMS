using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZongHua.Models
{
    /// <summary>
    /// 系统存储过程
    /// </summary>
    public class ProcName
    {
        /// <summary>
        /// 通过用户编号获取总公司信息
        /// 返回DataTable
        /// </summary>
        public const string GetCompanyByUserCode = "proc_getcomp_usercode";
        /// <summary>
        /// 管理员获取总公司信息
        /// 返回DataSet
        /// </summary>
        public const string GetCompanyByAdmin = "proc_getall_organization";
        /// <summary>
        /// 通过用户编号获取区域公司信息
        /// 返回DataTable
        /// </summary>
        public const string GetRegionByUserCode = "proc_getregion_usercode";
        /// <summary>
        /// 通过用户编号获取当前用户的操作权限的菜单
        /// 返回DataTable
        /// </summary>
        public const string GetSysMenuByUserCode = "proc_getmenu_usercode";
    }
}
