using System;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ZongHua.Data.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string msg = "";
            bool b = false;
            DataTable dt = new DataTable();
            string sql = "select * from db_goods";
            using (IDALayer da = DbFactory.GetDbServer())
            {
                dt = da.ExecuteTable(sql);
            }
            Console.WriteLine(b);
            Console.WriteLine(msg);
        }
    }
}
