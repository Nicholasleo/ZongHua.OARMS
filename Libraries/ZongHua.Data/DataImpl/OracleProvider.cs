using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZongHua.Data
{
    public class OracleProvider : IDALayer
    {
        #region
        private OracleConnection _conn = new OracleConnection();
        private DbParameterList _params = new DbParameterList();
        private bool isTran = true;
        private OracleTransaction _trans;
        #endregion
        public OracleProvider()
        {
            _conn.ConnectionString = DbFactory.DefaultConnectString;
            TimeOut = 300;
        }

        public OracleProvider(string conn)
        {
            _conn.ConnectionString = conn;
            TimeOut = 300;
        }

        ~OracleProvider()
        {
            Dispose(false);
        }


        public int TimeOut { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IDbConnection ConnectObj => throw new NotImplementedException();

        public DbParameterList ParameterList => throw new NotImplementedException();

        public void BulkCopy(DataTable dt, List<SqlBulkCopyColumnMapping> dtMapping)
        {
            throw new NotImplementedException();
        }

        public void BulkCopy(DataTable dt)
        {
            throw new NotImplementedException();
        }

        public void BulkCopy(DataTable dt, string deleteSql, string[] primaryKeys)
        {
            throw new NotImplementedException();
        }

        public void BulkCopyTable(string sqlInsert, IDbConnection connSelect, string sqlSelect)
        {
            throw new NotImplementedException();
        }

        public void BulkOption(bool isTran, BulkUpdateHandler bulkUp)
        {
            throw new NotImplementedException();
        }

        public void CloseConnection()
        {
            throw new NotImplementedException();
        }

        public void CreateParam(IDbCommand cmd, DataTable dtParam, DataRow rowValue)
        {
            throw new NotImplementedException();
        }

        public void CreateParam(IDbCommand cmd, string paramName, object paramValue)
        {
            throw new NotImplementedException();
        }

        public IDbDataParameter CreateParam(string paramName, object paramValue)
        {
            throw new NotImplementedException();
        }

        public IDbDataParameter CreateParam(string paramName, object paramValue, ParameterDirection paraDirect)
        {
            throw new NotImplementedException();
        }

        public DataSet ExecuteDataSet(bool isProc, string sql)
        {
            throw new NotImplementedException();
        }

        public DataSet ExecuteDataSet(string sql)
        {
            throw new NotImplementedException();
        }

        public int ExecuteNonQuery(string sql)
        {
            throw new NotImplementedException();
        }

        public int ExecuteNonQuery(string sql, bool isTran)
        {
            throw new NotImplementedException();
        }

        public int ExecuteNonQuery(string[] sql, bool isTran)
        {
            throw new NotImplementedException();
        }

        public int ExecuteNonQueryByLists(List<string> sqls, bool isTran)
        {
            throw new NotImplementedException();
        }

        public int ExecuteNonQueryProc(string procName)
        {
            throw new NotImplementedException();
        }

        public int ExecuteNonQueryProc(string procName, bool isTran)
        {
            throw new NotImplementedException();
        }

        public int ExecuteNonQueryProc(string procName, bool isTran, params object[] param)
        {
            throw new NotImplementedException();
        }

        public void ExecuteReader(string sqlCommand, ReaderDelegateHandler dbReader)
        {
            throw new NotImplementedException();
        }

        public void ExecuteReader<T>(string sql, IList<T> list) where T : new()
        {
            throw new NotImplementedException();
        }

        public void ExecuteReaderProc(string procName, ReaderDelegateHandler dbReader)
        {
            throw new NotImplementedException();
        }

        public void ExecuteReaderProc<T>(string procName, IList<T> list) where T : new()
        {
            throw new NotImplementedException();
        }

        public object ExecuteScalar(string sql)
        {
            throw new NotImplementedException();
        }

        public object ExecuteScalarProc(string procName)
        {
            throw new NotImplementedException();
        }

        public DataTable ExecuteTable(string sql)
        {
            throw new NotImplementedException();
        }

        public DataTable ExecuteTable(string sql, string tableName)
        {
            throw new NotImplementedException();
        }

        public DataTable ExecuteTableProc(string procName)
        {
            throw new NotImplementedException();
        }

        public DataTable ExecuteTableProc(string procName, string tableName)
        {
            throw new NotImplementedException();
        }

        public string GetConnectionString()
        {
            throw new NotImplementedException();
        }

        public bool OpenConnection(ref string msg)
        {
            throw new NotImplementedException();
        }

        public void RejectSubmit()
        {
            throw new NotImplementedException();
        }

        public void ResetConnectionString(string conn)
        {
            throw new NotImplementedException();
        }

        public void Submit()
        {
            throw new NotImplementedException();
        }

        #region IDisposable Support
        private bool disposedValue = false; // 要检测冗余调用

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 释放托管状态(托管对象)。
                }

                // TODO: 释放未托管的资源(未托管的对象)并在以下内容中替代终结器。
                // TODO: 将大型字段设置为 null。

                disposedValue = true;
            }
        }

        // TODO: 仅当以上 Dispose(bool disposing) 拥有用于释放未托管资源的代码时才替代终结器。
        // ~OracleProvider() {
        //   // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
        //   Dispose(false);
        // }

        // 添加此代码以正确实现可处置模式。
        public void Dispose()
        {
            // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
            Dispose(true);
            // TODO: 如果在以上内容中替代了终结器，则取消注释以下行。
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
