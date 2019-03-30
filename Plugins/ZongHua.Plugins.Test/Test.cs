using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZongHua.Interface;

namespace ZongHua.Plugins.Test
{
    public partial class Test : ITest
    {
        public string SayHello()
        {
            return "Hello World!";
        }

        public string SayWord(string word)
        {
            return string.Format("Hello {0}!", word);
        }


        public string SayWord(string word,string key)
        {
            if (key != "ZongHua")
            {
                return "你没有获得授权，无法使用该功能！";
            }
            else
            {
                return string.Format("Hello {0}!", word);
            }
        }
    }
}
