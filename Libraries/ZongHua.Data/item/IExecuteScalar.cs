using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZongHua.Data
{
    public interface IExecuteScalar
    {
        /// <summary>
        /// 执行普通SQL命令(不支持事务，主要用来读取数据)
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        object ExecuteScalar(string sql);
        /// <summary>
        /// 执行存储过程名称(不支持事务，主要用来读取数据)
        /// </summary>
        /// <param name="procName"></param>
        /// <returns></returns>
        object ExecuteScalarProc(string procName);
    }
}
