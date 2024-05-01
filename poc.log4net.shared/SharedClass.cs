using log4net;

namespace poc.log4net.shared
{
    public class SharedClass
    {
        private  static readonly ILog log = LogManager.GetLogger(typeof(SharedClass));
        //generated code
        public SharedClass()
        {
        }
        public void DoSomething()
        {
            log.Info("do something!");
        }
        public void DoSomethingElse()
        {
            log.Info("do something else!");
        }
    }
}