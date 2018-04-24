using System.Threading;
using IsItUpLogic;

namespace IsItUpService
{
    public class Service
    {
        private Thread _serviceThread;

        public void Start()
        {
            _serviceThread = new Thread(Run);
            _serviceThread.IsBackground = true;
            _serviceThread.Start();
        }

        public void Stop()
        {
            if (_serviceThread?.IsAlive ?? false) _serviceThread.Abort();
        }

        private void Run()
        {
            var upChecker = new NotifyingUpChecker();
            while (!upChecker.IsItUp(System.Configuration.ConfigurationManager.AppSettings["UrlToCheck"]))
            {
                Thread.Sleep(int.Parse(System.Configuration.ConfigurationManager.AppSettings["IntervalMilliseconds"]));
            }
            Stop();
        }
    }
}
