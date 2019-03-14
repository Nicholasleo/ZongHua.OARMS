using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZongHua.Data
{

    /// <summary>
    /// DataReader代理执行
    /// </summary>
    /// <param name="reader">读取器</param>
    public delegate void ReaderDelegateHandler(IDataReader reader);

    /// <summary>
    /// 批量操作委托
    /// </summary>
    /// <param name="cmd"></param>
    public delegate void BulkUpdateHandler(IDbCommand cmd);
    /// <summary>
    /// Sql参数列表类
    /// </summary>
    public class DbParameterList : List<System.Data.IDbDataParameter>
    {

    }

    /// <summary>
    /// 数据库访问接口
    /// </summary>
    public interface IDALayer : IExecuteNon,IExecuteReader,IExecuteScalar, IExecuteData, IBulkOperate,IDisposable
    {
        /// <summary>
        /// 超时时间
        /// </summary>
        int TimeOut { get; set; }
        /// <summary>
        /// 数据库连接对象
        /// </summary>
        IDbConnection ConnectObj { get; }
        /// <summary>
        /// 参数列表
        /// </summary>
        DbParameterList ParameterList { get; }        
        /// <summary>
        /// 打开连接数据库
        /// </summary>
        /// <param name="conn"></param>
        bool OpenConnection(ref string msg);
        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        void CloseConnection();
        /// <summary>
        /// 获取数据库连接字符串
        /// </summary>
        /// <returns></returns>
        string GetConnectionString();
        /// <summary>
        /// 重置连接字符串
        /// </summary>
        /// <param name="connString"></param>
        void ResetConnectionString(string conn);
        /// <summary>
        /// 创建参数
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="dtParam"></param>
        /// <param name="rowValue"></param>
        void CreateParam(IDbCommand cmd, DataTable dtParam, DataRow rowValue);
        /// <summary>
        /// 创建参数
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="paramName"></param>
        /// <param name="paramValue"></param>
        void CreateParam(IDbCommand cmd, string paramName, object paramValue);
        /// <summary>
        /// 创建参数
        /// </summary>
        /// <param name="paramName"></param>
        /// <param name="paramValue"></param>
        /// <returns></returns>
        IDbDataParameter CreateParam(string paramName, object paramValue);
        /// <summary>
        /// 创建参数
        /// </summary>
        /// <param name="paramName"></param>
        /// <param name="paramValue"></param>
        /// <param name="paraDirect"></param>
        /// <returns></returns>
        IDbDataParameter CreateParam(string paramName, object paramValue, ParameterDirection paraDirect);
        /// <summary>
        /// 提交(开启事务情况下使用)
        /// </summary>
        void Submit();
        /// <summary>
        /// 拒绝提交(开启事务情况下使用)
        /// </summary>
        void RejectSubmit();
    }
}
