using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZongHua.Data
{
    public interface IExecuteReader
    {
        /// <summary>
        /// 执行普通SQL,带有Reader读取功能(不支持事务，主要用来读取数据)
        /// 效率最快
        /// </summary>
        /// <param name="sqlCommand"></param>
        /// <param name="dbReader"></param>
        void ExecuteReader(string sqlCommand, ReaderDelegateHandler dbReader);
        /// <summary>
        /// 执行普通SQL,带有Reader读取功能(不支持事务，主要用来读取数据)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="list"></param>
        void ExecuteReader<T>(string sql, IList<T> list)
            where T : new();
        /// <summary>
        /// 执行存储过程名称,带有Reader读取功能(不支持事务，主要用来读取数据)
        /// 效率最快
        /// </summary>
        /// <param name="procName"></param>
        /// <param name="dbReader"></param>
        void ExecuteReaderProc(string procName, ReaderDelegateHandler dbReader);
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="procName"></param>
        /// <param name="list"></param>
        void ExecuteReaderProc<T>(string procName, IList<T> list)
           where T : new();
    }
}
