using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Layout;
using poc.log4net.shared;

namespace poc.log4net
{
    class Program
    {  
        /// <summary>
        /// 静态构造函数用于设置日志配置。
        /// </summary>
        static Program()
        {
            // 设置日志布局格式
            var repository = LogManager.GetRepository(System.Reflection.Assembly.GetEntryAssembly());
            var patternLayout = new PatternLayout
            {
                ConversionPattern = "%date{ABSOLUTE} %level %logger - %message%newline" // 定义日志输出格式
            };
            patternLayout.ActivateOptions(); // 激活日志布局配置

            // 配置将日志输出到控制台的Appender
            var consoleAppender = new ConsoleAppender
            {
                Layout = patternLayout, // 设置日志布局
            };
            consoleAppender.ActivateOptions(); // 激活控制台Appender配置

            // 将控制台Appender添加到根Logger
            BasicConfigurator.Configure(repository, consoleAppender);
        }

        
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));
        public static void Main(string[] args)
        {
            log .Info("Hello World!");
            SharedClass sharedClass = new SharedClass();
            sharedClass.DoSomething();
            sharedClass.DoSomethingElse();
        }
    }
}