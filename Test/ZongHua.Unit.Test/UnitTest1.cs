using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ZongHua.Unit.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Console.WriteLine(ZongHua.Core.Test.Instance.SayHello());
        }

        [TestMethod]
        public void TestMethod2()
        {
            Console.WriteLine(ZongHua.Core.Test.Instance.SayWord("NicholasLeo"));
        }

        [TestMethod]
        public void TestMethod3()
        {
            Console.WriteLine(ZongHua.Core.Test.Instance.SayWord("NicholasLeo", "wanjin"));
        }
    }
}
