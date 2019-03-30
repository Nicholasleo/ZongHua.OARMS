using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ZongHua.Data
{
    public class MySqlProvider : IDALayer
    {
        #region
        private MySqlConnection _conn = new MySqlConnection();
        private DbParameterList _params = new DbParameterList();
        private bool isTran = true;
        private MySqlTransaction _trans;
        #endregion
        public MySqlProvider()
        {
            _conn.ConnectionString = DbFactory.DefaultConnectString;
            TimeOut = 300;
        }

        public MySqlProvider(string conn)
        {
            _conn.ConnectionString = conn;
            TimeOut = 300;
        }

        ~MySqlProvider()
        {
            Dispose(false);
        }

        #region 事务

        /// <summary>
        /// 提交事务
        /// </summary>
        private void CommitTranscation()
        {
            if (_trans != null)
            {
                _trans.Commit();
                _trans = null;
            }
        }

        /// <summary>
        /// 回滚事务
        /// </summary>
        private void RollbackTranscation()
        {
            if (_trans != null)
            {
                _trans.Rollback();
                _trans = null;
            }
        }

        #endregion

        #region Base
        public int TimeOut { get; set; }

        public IDbConnection ConnectObj => _conn;

        public DbParameterList ParameterList => _params;


        public string GetConnectionString()
        {
            return _conn.ConnectionString;
        }

        public bool OpenConnection(ref string msg)
        {
            try
            {
                if (string.IsNullOrEmpty(_conn.ConnectionString))
                {
                    if (string.IsNullOrEmpty(DbFactory.DefaultConnectString))
                    {
                        msg = "数据库连接字符串为空，请先配置数据库连接字符串";
                        return false;
                    }
                    else
                    {
                        _conn.ConnectionString = DbFactory.DefaultConnectString;
                        msg = "数据库连接成功！";
                    }
                }
                _conn.Open();
                msg = "数据库连接成功！";
            }
            catch (MySqlException ex)
            {
                msg = ex.Message;
                return false;
            }
            finally
            {
                _conn.Close();
            }
            return true;
        }

        public void RejectSubmit()
        {
            RollbackTranscation();
        }

        public void ResetConnectionString(string conn)
        {
            _conn.ConnectionString = conn;
        }

        public void Submit()
        {
            CommitTranscation();
        }

        public void CloseConnection()
        {
            ClearParameter();
            if (_trans == null && _conn.State != ConnectionState.Closed)
                _conn.Close();
        }

        #region CreateParam impl
        public void CreateParam(IDbCommand cmd, DataTable dtParam, DataRow rowValue)
        {
            if (dtParam != null && dtParam.Rows.Count > 0 && dtParam.Columns.Count > 0 && rowValue != null)
            {
                StringBuilder sb = new StringBuilder();
                foreach (DataRow row in dtParam.Rows)
                {
                    string columnname = row[1].ToString();
                    if (rowValue.Table.Columns.Contains(columnname))
                    {
                        MySqlParameter p = new MySqlParameter();
                        p.ParameterName = row[0].ToString();
                        object value = rowValue[row[1].ToString()];
                        if (rowValue.Table.Columns[columnname].DataType == typeof(byte[]))
                        {
                            if (value == DBNull.Value) value = new byte[0];
                            p.MySqlDbType = MySqlDbType.Byte;
                        }
                        p.Value = value;
                        cmd.Parameters.Add(p);
                        sb.Append(string.Format(" {0}='{1}',", row[0], rowValue[row[1].ToString()]));
                    }
                }
            }
        }

        public void CreateParam(IDbCommand cmd, string paramName, object paramValue)
        {
            MySqlParameter _param= new MySqlParameter();
            _param.ParameterName = paramName;
            _param.Value = paramValue == null ? DBNull.Value : paramValue;
            cmd.Parameters.Add(_param);
        }

        public IDbDataParameter CreateParam(string paramName, object paramValue)
        {
            return CreateParam(paramName, paramValue, ParameterDirection.Input);
        }

        public IDbDataParameter CreateParam(string paramName, object paramValue, ParameterDirection paraDirect)
        {
            IDbDataParameter _param = new MySqlParameter();
            _param.ParameterName = paramName;
            _param.Value = paramValue == null ? DBNull.Value : paramValue;
            _param.Direction = paraDirect;
            _params.Add(_param);
            return _param;
        }
        #endregion

        #endregion

        #region Private Method

        /// <summary>
        /// 添加参数
        /// </summary>
        private void AddParameter(IDbCommand cmd)
        {
            if (ParameterList != null)
                foreach (IDbDataParameter var in ParameterList)
                {
                    cmd.Parameters.Add(var);
                }
        }

        /// <summary>
        /// 清除所有参数
        /// </summary>
        private void ClearParameter()
        {
            ParameterList.Clear();
        }

        /// <summary>
        /// 打开连接
        /// </summary>
        private void Open()
        {
            Open(false);
        }

        /// <summary>
        /// 开启连接
        /// </summary>
        /// <param name="isTrans">是否开启事务</param>
        private void Open(bool isTrans)
        {
            if (string.IsNullOrEmpty(_conn.ConnectionString))
            {
                if (string.IsNullOrEmpty(DbFactory.DefaultConnectString))
                    throw new Exception("MySql数据库连接字符串为空，请核对。");
                else
                {
                    _conn.ConnectionString = DbFactory.DefaultConnectString;
                }
            }
            if (_conn.State == ConnectionState.Closed)
            {
                _conn.Open();
            }
            if (isTrans && _trans == null)
                _trans = _conn.BeginTransaction();
        }

        #endregion

        #region Bulk
        public void BulkCopy(DataTable dt, List<SqlBulkCopyColumnMapping> dtMapping)
        {
            throw new NotImplementedException();
        }

        public void BulkCopy(DataTable dt)
        {
            throw new NotImplementedException();
            //if (dt == null || dt.Rows.Count == 0)
            //    return;

            //MySqlBulkLoader mySqlBulk = null;
            //try
            //{
            //    Open(true);
            //    string tmpPath = Path.Combine(Directory.GetCurrentDirectory(), "Temp.csv"); //Path.GetTempFileName();
            //    string csv = DataTableToCsv(dt);
            //    File.WriteAllText(tmpPath, csv);
            //    mySqlBulk = new MySqlBulkLoader(_conn)
            //    {
            //        FieldTerminator = ",",
            //        FieldQuotationCharacter = '"',
            //        EscapeCharacter = '"',
            //        LineTerminator = "\r\n",
            //        NumberOfLinesToSkip = 0,
            //        TableName = dt.TableName,
            //    };
            //    mySqlBulk.Load();
            //bulkCopy = new SqlBulkCopy(_conn, SqlBulkCopyOptions.CheckConstraints | SqlBulkCopyOptions.KeepIdentity, (SqlTransaction)_trans);
            //bulkCopy.DestinationTableName = dt.TableName;
            //bulkCopy.BatchSize = dt.Rows.Count;
            //if (dt.Rows.Count != 0)
            //{
            //    //批量操作前 清除原来的数据
            //    using (SqlCommand cmd = new SqlCommand(string.Format("delete from {0}", dt.TableName), _conn))
            //    {
            //        cmd.Transaction = _trans;
            //        cmd.ExecuteNonQuery();
            //    }
            //    foreach (DataColumn cln in dt.Columns)
            //    {
            //        bulkCopy.ColumnMappings.Add(cln.ColumnName, cln.ColumnName);
            //    }
            //    bulkCopy.BulkCopyTimeout = 360;
            //    bulkCopy.WriteToServer(dt);
            //}
            //}
            //catch (Exception ex)
            //{
            //    RollbackTranscation();
            //    throw ex;
            //}
            //finally
            //{
            //    if (bulkCopy != null)
            //        bulkCopy.Close();
            //    CloseConnection();
            //}
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
        #endregion

        #region ExecuteData impl
        public DataSet ExecuteDataSet(bool isProc, string sql)
        {
            DataSet ds = new DataSet("ds1");
            try
            {
                Open();
                using (IDbCommand cmd = _conn.CreateCommand())
                {
                    cmd.CommandType = isProc ? CommandType.StoredProcedure : CommandType.Text;
                    cmd.CommandTimeout = 600;
                    cmd.CommandText = isProc ? sql.Trim() : sql;
                    if (ParameterList != null)
                    {
                        foreach (DbParameter param in ParameterList)
                        {
                            cmd.Parameters.Add(param);
                        }
                    }
                    IDbDataAdapter adp = new MySqlDataAdapter();
                    adp.SelectCommand = cmd;
                    adp.Fill(ds);
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return ds;
        }

        public DataSet ExecuteDataSet(string sql)
        {
            return ExecuteDataSet(false, sql);
        }
        public DataTable ExecuteTable(string sql)
        {
            return ExecuteTable(sql, "Data");
        }

        public DataTable ExecuteTable(string sql, string tableName)
        {
            DataSet ds = new DataSet();
            DataTable dt = null;
            try
            {
                Open();
                using (IDbCommand comm = _conn.CreateCommand())
                {
                    comm.CommandType = CommandType.Text;
                    comm.CommandText = sql;
                    comm.CommandTimeout = TimeOut;
                    AddParameter(comm);
                    IDbDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = comm;
                    da.Fill(ds);
                }
                dt = ds.Tables[0].Copy();
                dt.TableName = tableName;
            }
            catch (MySqlException ex)
            {
                RollbackTranscation();
                CloseConnection();
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                RollbackTranscation();
                CloseConnection();
                throw new Exception(ex.Message);
            }
            finally
            {
                ClearParameter();
                ds.Clear();
                ds.Dispose();
            }
            return dt;
        }

        public DataTable ExecuteTableProc(string procName)
        {
            return ExecuteTableProc(procName, "Data");
        }

        public DataTable ExecuteTableProc(string procName, string tableName)
        {
            DataSet ds = new DataSet();
            DataTable dt = null;
            try
            {
                Open();
                using (IDbCommand comm = _conn.CreateCommand())
                {
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.CommandText = procName;
                    comm.CommandTimeout = TimeOut;
                    AddParameter(comm);
                    IDbDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = comm;
                    da.Fill(ds);
                }
                if (ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0].Copy();
                    dt.TableName = tableName;
                }
            }
            catch (MySqlException ex)
            {
                RollbackTranscation();
                CloseConnection();
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                RollbackTranscation();
                CloseConnection();
                throw new Exception(ex.Message);
            }
            finally
            {
                ClearParameter();
                ds.Clear();
                ds.Dispose();
            }
            return dt;
        }
        #endregion

        #region ExecuteNon impl
        public int ExecuteNonQuery(string sql)
        {
            return ExecuteNonQuery(sql, true);
        }

        public int ExecuteNonQuery(string sql, bool isTran)
        {
            int result = 0;
            try
            {
                Open(isTran);
                using (IDbCommand comm = _conn.CreateCommand())
                {
                    comm.Connection = _conn;
                    if (isTran && _trans != null) comm.Transaction = _trans;
                    comm.CommandType = CommandType.Text;
                    comm.CommandText = sql;
                    comm.CommandTimeout = this.TimeOut;
                    AddParameter(comm);
                    result = comm.ExecuteNonQuery();
                }
            }
            catch (DbException ex)
            {
                RollbackTranscation();
                CloseConnection();
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                RollbackTranscation();
                CloseConnection();
                throw new Exception(ex.Message);
            }
            finally
            {
                ClearParameter();
                CommitTranscation();
            }
            return result;
        }

        public int ExecuteNonQuery(string[] sql, bool isTran)
        {
            if (sql == null)
                return -1;
            int result = 0;
            try
            {
                Open(isTran);
                using (IDbCommand comm = _conn.CreateCommand())
                {
                    comm.Connection = _conn;
                    if (isTran && _trans != null) comm.Transaction = _trans;
                    comm.CommandType = CommandType.Text;
                    comm.CommandTimeout = TimeOut;
                    foreach (string sqlCmd in sql)
                    {
                        if (string.IsNullOrEmpty(sqlCmd)) continue;
                        comm.CommandText = sqlCmd;
                        AddParameter(comm);
                        result += comm.ExecuteNonQuery();
                    }
                    if (isTran)
                        CommitTranscation();
                }
            }
            catch (DbException ex)
            {
                RollbackTranscation();
                CloseConnection();
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                RollbackTranscation();
                CloseConnection();
                throw new Exception(ex.Message);
            }
            finally
            {
                ClearParameter();
            }
            return result;
        }

        public int ExecuteNonQueryByLists(List<string> sqls, bool isTran)
        {
            if (sqls == null || sqls.Count <= 0)
                return -1;
            int result = 0;
            try
            {
                Open(isTran);
                using (IDbCommand comm = _conn.CreateCommand())
                {
                    comm.Connection = _conn;
                    if (isTran && _trans != null) comm.Transaction = _trans;
                    comm.CommandType = CommandType.Text;
                    comm.CommandTimeout = TimeOut;
                    foreach (string sqlCmd in sqls)
                    {
                        if (string.IsNullOrEmpty(sqlCmd)) continue;
                        comm.CommandText = sqlCmd;
                        AddParameter(comm);
                        result += comm.ExecuteNonQuery();
                    }
                    if(isTran)
                        CommitTranscation();
                }
            }
            catch (DbException ex)
            {
                RollbackTranscation();
                CloseConnection();
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                RollbackTranscation();
                CloseConnection();
                throw new Exception(ex.Message);
            }
            finally
            {
                ClearParameter();
            }
            return result;
        }

        public int ExecuteNonQueryProc(string procName)
        {
            return ExecuteNonQueryProc(procName, true);
        }



        public int ExecuteNonQueryProc(string procName, bool isTran)
        {

            int result = 0;
            try
            {
                Open(isTran);
                using (IDbCommand comm = _conn.CreateCommand())
                {
                    comm.Connection = _conn;
                    if (isTran && _trans != null) comm.Transaction = _trans;
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.CommandText = procName;
                    comm.CommandTimeout = this.TimeOut;
                    AddParameter(comm);
                    result = comm.ExecuteNonQuery();
                }
            }
            catch (DbException ex)
            {
                RollbackTranscation();
                CloseConnection();
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                RollbackTranscation();
                CloseConnection();
                throw new Exception(ex.Message);
            }
            finally
            {
                ClearParameter();
                CommitTranscation();
            }
            return result;
        }

        public int ExecuteNonQueryProc(string procName, bool isTran,params object[] param)
        {

            int result = 0;
            try
            {
                Open(isTran);
                using (IDbCommand cmd = _conn.CreateCommand())
                {
                    cmd.Connection = _conn;
                    if (isTran && _trans != null) cmd.Transaction = _trans;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = procName;
                    cmd.CommandTimeout = this.TimeOut;
                    if (param != null)
                    {
                        for (int i = 0; i < param.Length/2; i++)
                        {
                            CreateParam(cmd, param[i * 2].ToString(), param[i * 2 + 1]);
                        }
                    }
                    AddParameter(cmd);
                    result = cmd.ExecuteNonQuery();
                }
            }
            catch (DbException ex)
            {
                RollbackTranscation();
                CloseConnection();
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                RollbackTranscation();
                CloseConnection();
                throw new Exception(ex.Message);
            }
            finally
            {
                ClearParameter();
                CommitTranscation();
            }
            return result;
        }
        #endregion

        #region ExecuteReader impl
        public void ExecuteReader(string sqlCommand, ReaderDelegateHandler dbReader)
        {

            try
            {
                Open();
                using (IDbCommand comm = _conn.CreateCommand())
                {
                    comm.Connection = _conn;
                    comm.CommandType = CommandType.Text;
                    comm.CommandText = sqlCommand;
                    AddParameter(comm);
                    using (IDataReader dr = comm.ExecuteReader())
                    {
                        if (dbReader != null)
                            dbReader(dr);
                    }
                }
            }
            catch (DbException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ClearParameter();
                CloseConnection();
            }
        }

        public void ExecuteReader<T>(string sql, IList<T> list) where T : new()
        {
            try
            {
                Open();
                using (IDbCommand comm = _conn.CreateCommand())
                {
                    comm.Connection = _conn;
                    comm.CommandType = CommandType.Text;
                    comm.CommandText = sql;
                    AddParameter(comm);
                    using (IDataReader dr = comm.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        Type type = typeof(T);
                        PropertyInfo[] properys = type.GetProperties();
                        while (dr.Read())
                        {
                            T t = new T();
                            foreach (PropertyInfo var in properys)
                            {
                                var.SetValue(t, dr[var.Name], null);
                            }
                            list.Add(t);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                RollbackTranscation();
                CloseConnection();
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                RollbackTranscation();
                CloseConnection();
                throw new Exception(ex.Message);
            }
            finally
            {
                ClearParameter();
                CloseConnection();
            }
        }

        public void ExecuteReaderProc(string procName, ReaderDelegateHandler dbReader)
        {
            try
            {
                Open();
                using (IDbCommand comm = _conn.CreateCommand())
                {
                    comm.Connection = _conn;
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.CommandText = procName;
                    AddParameter(comm);
                    using (IDataReader dr = comm.ExecuteReader())
                    {
                        if (dbReader != null) dbReader(dr);
                    }
                }
            }
            catch (MySqlException ex)
            {
                RollbackTranscation();
                CloseConnection();
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                RollbackTranscation();
                CloseConnection();
                throw new Exception(ex.Message);
            }
            finally
            {
                ClearParameter();
                CloseConnection();
            }
        }

        public void ExecuteReaderProc<T>(string procName, IList<T> list) where T : new()
        {
            try
            {
                Open();
                using (IDbCommand comm = _conn.CreateCommand())
                {
                    comm.Connection = _conn;
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.CommandText = procName;
                    AddParameter(comm);
                    using (IDataReader dr = comm.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        Type type = typeof(T);
                        PropertyInfo[] properys = type.GetProperties();
                        while (dr.Read())
                        {
                            T t = new T();
                            foreach (PropertyInfo var in properys)
                            {
                                var.SetValue(t, dr[var.Name], null);
                            }
                            list.Add(t);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                RollbackTranscation();
                CloseConnection();
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                RollbackTranscation();
                CloseConnection();
                throw new Exception(ex.Message);
            }
            finally
            {
                ClearParameter();
                CloseConnection();
            }
        }
        #endregion

        #region ExecuteScalar impl
        public object ExecuteScalar(string sql)
        {
            object result = null;
            try
            {
                Open(false);
                using (IDbCommand comm = _conn.CreateCommand())
                {
                    comm.Connection = _conn;
                    comm.CommandType = CommandType.Text;
                    comm.CommandText = sql;
                    AddParameter(comm);
                    result = comm.ExecuteScalar();
                }
            }
            catch (MySqlException ex)
            {
                RollbackTranscation();
                CloseConnection();
                throw new Exception(ex.Message);
            }
            finally
            {
                ClearParameter();
            }
            return result;
        }

        public object ExecuteScalarProc(string procName)
        {
            object result = null;
            try
            {
                Open(false);
                using (IDbCommand comm = _conn.CreateCommand())
                {
                    comm.Connection = _conn;
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.CommandText = procName;
                    AddParameter(comm);
                    result = comm.ExecuteScalar();
                }
            }
            catch (MySqlException ex)
            {
                RollbackTranscation();
                CloseConnection();
                throw new Exception(ex.Message);
            }
            finally
            {
                ClearParameter();
            }
            return result;
        } 
        #endregion
             
        #region IDisposable Support
        private bool disposedValue = false; // 要检测冗余调用

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 释放托管状态(托管对象)。
                    CloseConnection();
                }

                // TODO: 释放未托管的资源(未托管的对象)并在以下内容中替代终结器。
                // TODO: 将大型字段设置为 null。

                disposedValue = true;
            }
        }

        // TODO: 仅当以上 Dispose(bool disposing) 拥有用于释放未托管资源的代码时才替代终结器。
        // ~MySqlProvider() {
        //   // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
        //   Dispose(false);
        // }

        // 添加此代码以正确实现可处置模式。
        public void Dispose()
        {
            // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
            Dispose(true);
            // TODO: 如果在以上内容中替代了终结器，则取消注释以下行。
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
