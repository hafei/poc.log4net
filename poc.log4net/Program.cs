using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Layout;
using poc.log4net.shared;

namespace poc.log4net
{
    internal class Program
    {  
        static Program()
        {
            // 设置配置
            var repository = LogManager.GetRepository(System.Reflection.Assembly.GetEntryAssembly());
            var patternLayout = new PatternLayout
            {
                ConversionPattern = "%date{ABSOLUTE} %level %logger - %message%newline"
            };
            patternLayout.ActivateOptions();

            var consoleAppender = new ConsoleAppender
            {
                Layout = patternLayout,
            };
            consoleAppender.ActivateOptions();

            // 添加控制台Appender到root logger
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