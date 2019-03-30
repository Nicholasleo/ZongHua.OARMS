using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ZongHua.Data
{
    public class DbFactory
    {
        private static string _connstring = string.Empty;
        private static MySqlProvider _mySqlInstance = null;
        private static MSSqlProvider _msSqlInstance = null;
        private static OracleProvider _oracleInstance = null;
        private static string currentDbType = DatabaseType.MySqlType;

        static DbFactory()
        {
            InitializeDefault();
        }
        /// <summary>
        /// 获取配置
        /// </summary>
        private static void InitializeDefault()
        {
            string conn = ConfigurationManager.ConnectionStrings["DbConnString"].ToString();
            string dbType = ConfigurationManager.AppSettings["dbType"].ToString();
            SetDefaultConnectString(dbType, conn);
        }
        /// <summary>
        /// 默认连接字符串
        /// </summary>
        public static string DefaultConnectString {
            get {
                if(string.IsNullOrEmpty(_connstring))
                {
                    InitializeDefault();
                }
                return _connstring;
            }
            private set { _connstring = value; }
        }

        /// <summary>
        /// 更新默认数据库配置
        /// </summary>
        public static void UpdateDefaultConnectionString()
        {
            InitializeDefault();
        }

        #region MySql
        private static IDALayer GetNewMySqlServer()
        {
            return new MySqlProvider();
        }
        private static IDALayer GetNewMySqlServer(string conn)
        {
            return new MySqlProvider(conn);
        }
        private static IDALayer GetMySqlServer()
        {
            if (_mySqlInstance == null)
                _mySqlInstance = new MySqlProvider();
            return _mySqlInstance;
        }
        private static IDALayer GetMySqlServer(string conn)
        {
            if (_mySqlInstance == null)
                _mySqlInstance = new MySqlProvider(conn);
            return _mySqlInstance;
        }
        #endregion
        #region MSSql
        private static IDALayer GetNewMSSqlServer()
        {
            return new MSSqlProvider();
        }
        private static IDALayer GetNewMSSqlServer(string conn)
        {
            return new MSSqlProvider(conn);
        }
        private static IDALayer GetMSSqlServer()
        {
            if (_msSqlInstance == null)
                _msSqlInstance = new MSSqlProvider();
            return _msSqlInstance;
        }
        private static IDALayer GetMSSqlServer(string conn)
        {
            if (_msSqlInstance == null)
                _msSqlInstance = new MSSqlProvider(conn);
            return _msSqlInstance;
        }
        #endregion
        #region Oracle
        private static IDALayer GetNewOracleServer()
        {
            return new OracleProvider();
        }
        private static IDALayer GetNewOracleServer(string conn)
        {
            return new OracleProvider(conn);
        }
        private static IDALayer GetOracleServer()
        {
            if (_oracleInstance == null)
                _oracleInstance = new OracleProvider();
            return _oracleInstance;
        }
        private static IDALayer GetOracleServer(string conn)
        {
            if (_oracleInstance == null)
                _oracleInstance = new OracleProvider(conn);
            return _oracleInstance;
        }
        #endregion


        /// <summary>
        /// 通用数据库提供服务（后台动态配置数据库）
        /// </summary>
        /// <returns></returns>
        public static IDALayer GetDbServer()
        {
            switch (currentDbType)
            {
                case DatabaseType.MySqlType:
                    return GetMySqlServer();
                case DatabaseType.OracleType:
                    return GetOracleServer();
                case DatabaseType.MSSqlType:
                    return GetMSSqlServer();
                default:
                    return GetMySqlServer();
            }
        }

        /// <summary>
        /// 通用数据库提供服务（后台动态配置数据库）
        /// </summary>
        /// <param name="conn">新连接字符串</param>
        /// <returns></returns>
        public static IDALayer GetDbServer(string conn)
        {
            switch (currentDbType)
            {
                case DatabaseType.MySqlType:
                    return GetMySqlServer(conn);
                case DatabaseType.MSSqlType:
                    return GetMSSqlServer(conn);
                case DatabaseType.OracleType:
                    return GetOracleServer(conn);
                default:
                    return GetMySqlServer(conn);
            }
        }

        /// <summary>
        /// 通用数据库提供服务（后台动态配置数据库）
        /// </summary>
        /// <param name="dbtype">数据库类型</param>
        /// <param name="connconnString">新连接字符串</param>
        /// <returns></returns>
        public static IDALayer GetNewDbServer(string dbtype, string conn)
        {
            switch (dbtype.ToLower())
            {
                case "mysql":
                    return GetMySqlServer(conn);
                case "oracle":
                    return GetOracleServer(conn);
                case "mssql":
                    return GetMySqlServer(conn);
                default:
                    throw new Exception("数据访问组件不支持:" + dbtype);
            }
        }



        /// <summary>
        /// 通用数据库提供服务（后台动态配置数据库）
        /// </summary>
        /// <returns></returns>
        public static IDALayer GetNewDbServer()
        {
            switch (currentDbType)
            {
                case DatabaseType.MySqlType:
                    return GetNewMySqlServer();
                case DatabaseType.MSSqlType:
                    return GetNewMSSqlServer();
                case DatabaseType.OracleType:
                    return GetNewOracleServer();
                default:
                    return GetNewMySqlServer();
            }
        }

        /// <summary>
        /// 设置默认的链接字符串
        ///  没有通过默认配置文件配置的需要手动设置<appSettings></appSettings>
        /// </summary>
        public static void SetDefaultConnectString(string dbtype, string conn)
        {
            _connstring = conn;
            switch (dbtype.ToLower())
            {
                case DatabaseType.MSSqlType:
                    currentDbType = dbtype;
                    break;
                case DatabaseType.MySqlType:
                    currentDbType = dbtype;
                    break;
                case DatabaseType.OracleType:
                    currentDbType = dbtype;
                    break;
                default:
                    throw new Exception("访问组件不支持数据库类型：" + dbtype);
            }
        }

    }
    public class DatabaseType
    {
        public const string MSSqlType = "sqlserver";
        public const string OracleType = "oracle";
        public const string MySqlType = "mysql";
    }
}
