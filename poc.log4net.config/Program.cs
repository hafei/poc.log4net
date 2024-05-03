using System.IO;
using log4net;
using log4net.Config;
using poc.log4net.shared;

namespace poc.log4net.config
{
    class Program
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Program));

        static Program()
        {
            XmlConfigurator.Configure(new FileInfo("config/log4net.config.xml"));
        }

        public static void Main(string[] args)
        {
            Log.Info("Log4net初始化成功");

            // 示例：记录不同级别的日志
            Log.Debug("这是一条调试日志");
            Log.Info("这是一条信息日志");
            Log.Warn("这是一条警告日志");
            Log.Error("这是一条错误日志");
            Log.Fatal("这是一条致命错误日志");
            SharedClass sharedClass = new SharedClass();
            sharedClass.DoSomething();
            sharedClass.DoSomethingElse();
            //循环写log 测试 log 4net 配置
            for (int i = 0; i < 100; i++)
            {
                Log.Info("这是一条信息日志");
            }
        }
    }
}