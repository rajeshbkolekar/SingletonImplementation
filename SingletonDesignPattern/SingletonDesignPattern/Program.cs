using System;
using System.Threading;

namespace SingletonDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread thread = new Thread(new ThreadStart(LogUser1));
            Thread thread2 = new Thread(new ThreadStart(LogUser2));
            thread.Start();
            thread2.Start();

            thread.Join();
            thread2.Join();
        }

        public static void LogUser1()
        {
            var logger1 = Logger.GetLogger();

            logger1.Log("Message from logger1");

        }

        public static void LogUser2()
        {
            var logger1 = Logger.GetLogger();

            logger1.Log("Message from logger2");

        }
    }
}
