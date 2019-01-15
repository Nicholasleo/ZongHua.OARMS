using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZongHua.Data
{
    public class Test
    {
        public void InitTest()
        {
            var cfg = new NHibernate.Cfg.Configuration().Configure("Configs/hibernate.cfg.xml");
            using (ISessionFactory sessionProvider = cfg.BuildSessionFactory())
            {
            };
        }
    }
}
