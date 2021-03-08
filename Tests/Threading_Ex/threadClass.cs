using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threading_Ex
{
    public class threadClass
    {
        private int _sleepTime;
        private string _message;
        public threadClass(int sleepTime, string message)
        {
            _sleepTime = sleepTime;
            _message = message;
        }
        public void ThreadClassMethod()
        {
            Thread.Sleep(_sleepTime);
            Console.WriteLine(_message);
        }

    }
}
