using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZongHua.Interface
{
    public partial interface ITest
    {
        string SayHello();
        string SayWord(string word);
        string SayWord(string word, string key);
    }
}
