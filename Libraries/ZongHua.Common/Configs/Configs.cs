using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;

namespace ZongHua.Common
{
    public class Configs
    {
        public static string GetConfig(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
