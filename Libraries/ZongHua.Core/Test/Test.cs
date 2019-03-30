using System;
using System.IO;
using ZongHua.Interface;

namespace ZongHua.Core
{
    public class Test
    {
        private static ITest _itest = null;

        static Test()
        {
            try
            {
                string[] fileName = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "ZongHua.Plugins.*.dll", SearchOption.TopDirectoryOnly);
                _itest = (ITest)Activator.CreateInstance(Type.GetType(
                    string.Format("ZongHua.Plugins.{0}.Test,ZongHua.Plugins.{0}",fileName[0].Substring(fileName[0].LastIndexOf("Plugins.")+8).Replace(".dll",""))
                    , false
                    , true
                    ));
            }
            catch (Exception)
            {
                throw new Exception("创建'异步策略对象'失败,可能存在的原因:未将'异步策略程序集'添加到bin目录中;'异步策略程序集'文件名不符合'ZongHua.Plugins.{策略名称}.dll'格式");
            }
        }

        public static ITest Instance
        {
            get { return _itest; }
        }
    }
}
