using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZongHua.Data
{
    public interface IExecuteNon
    {
        /// <summary>
        /// 执行普通SQL命令
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        int ExecuteNonQuery(string sql);
        /// <summary>
        /// 执行普通SQL命令(此功能支持带事务)
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="isTran"></param>
        /// <returns></returns>
        int ExecuteNonQuery(string sql,bool isTran);
        /// <summary>
        /// 执行批量SQL命令(此功能支持带事务)
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="isTran"></param>
        /// <returns></returns>
        int ExecuteNonQuery(string[] sql, bool isTran);
        /// <summary>
        /// 执行批量SQL命令(此功能支持带事务)
        /// </summary>
        /// <param name="sqls"></param>
        /// <param name="isTran"></param>
        /// <returns></returns>
        int ExecuteNonQueryByLists(List<string> sqls, bool isTran);
        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="procName"></param>
        /// <returns></returns>
        int ExecuteNonQueryProc(string procName);
        /// <summary>
        /// 执行存储过程(此功能支持带事务)
        /// </summary>
        /// <param name="procName"></param>
        /// <param name="isTran"></param>
        /// <returns></returns>
        int ExecuteNonQueryProc(string procName,bool isTran);
        /// <summary>
        /// 执行存储过程(此功能支持带事务)
        /// </summary>
        /// <param name="procName"></param>
        /// <param name="isTran"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        int ExecuteNonQueryProc(string procName, bool isTran, params object[] param);
    }
}
