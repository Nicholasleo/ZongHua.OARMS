using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZongHua.Data
{
    public interface IBulkOperate
    {
        /// <summary>
        /// 高效批量操作（添加参数注意）
        /// 如果使用参数，则需要传输 cmd进入
        /// void CreateParam(IDbCommand cmd, string paramName, object paramValue);
        /// </summary>
        /// <param name="isTran"></param>
        /// <param name="bulkUp"></param>
        void BulkOption(bool isTran, BulkUpdateHandler bulkUp);
        /// <summary>
        /// 数据库表数据批量导入
        /// </summary>
        /// <param name="sqlInsert"></param>
        /// <param name="connSelect"></param>
        /// <param name="sqlSelect"></param>
        void BulkCopyTable(string sqlInsert, IDbConnection connSelect, string sqlSelect);
        /// <summary>
        /// 数据批量录入
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="dtMapping"></param>
        void BulkCopy(DataTable dt, List<SqlBulkCopyColumnMapping> dtMapping);
        /// <summary>
        /// 批量插入数据
        /// </summary>
        /// <param name="dt"></param>
        void BulkCopy(DataTable dt);
        /// <summary>
        /// 批量插入数据（用于增量更新，但无法更新已删除的数据）
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="deleteSql"></param>
        /// <param name="primaryKeys"></param>
        void BulkCopy(DataTable dt, string deleteSql, string[] primaryKeys);
    }
}
