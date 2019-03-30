using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZongHua.Data
{
    public interface IExecuteData
    {
        /// <summary>
        /// 执行SQL,返回一个Table(不支持事务，主要用来读取数据)
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        DataTable ExecuteTable(string sql);
        /// <summary>
        /// 执行SQL,返回一个Table(不支持事务，主要用来读取数据)
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        DataTable ExecuteTable(string sql, string tableName);
        /// <summary>
        /// 执行存储过程名称,返回一个Table(不支持事务，主要用来读取数据)
        /// </summary>
        /// <param name="procName"></param>
        /// <returns></returns>
        DataTable ExecuteTableProc(string procName);
        /// <summary>
        /// 执行存储过程名称,返回一个Table(不支持事务，主要用来读取数据)
        /// </summary>
        /// <param name="procName"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        DataTable ExecuteTableProc(string procName, string tableName);
        /// <summary>
        /// 执行sql(语句/存储过程)返回dataset
        /// </summary>
        /// <param name="isProc"></param>
        /// <param name="执行sql"></param>
        /// <returns></returns>
        DataSet ExecuteDataSet(bool isProc, string sql);
        /// <summary>
        /// 执行sql 返回dataset
        /// </summary>
        /// <param name="执行sql"></param>
        /// <returns></returns>
        DataSet ExecuteDataSet(string sql);
    }
}
