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
            string conn = "";// ConfigurationManager.ConnectionStrings["DbConnString"].ToString();
            conn = "server=localhost;Database=shopsn;uid=root;pwd=root;charset=utf8";
            _connstring = conn;
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

            if (dbtype.ToLower() == "mysql")
            {
                return GetMySqlServer(conn);
            }
            //else if (dbtype1.ToLower() == "oracle")
            //{
            //    return GetNewOracleServer(connString);
            //}
            //else if (dbtype1.ToLower() == "sqlite")
            //{
            //    return GetNewSqliteServer(connString);
            //}
            //else if (dbtype1.ToLower() == "odbc")
            //{
            //    return GetNewOdbcServer(connString);
            //}
            else
            {
                throw new Exception("数据访问组件不支持:" + dbtype);
            }
        }

    }
    public class DatabaseType
    {
        public const string SqlServerType = "sqlserver";
        public const string OracleType = "oracle";
        public const string MySqlType = "mysql";
    }
}
