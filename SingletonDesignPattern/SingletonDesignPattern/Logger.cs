using System;
using System.Threading;

namespace SingletonDesignPattern
{
    public class Logger
    {
        private static int _count;
        private static Logger _instance;
        static Mutex mutex = new Mutex();  

        // first step so that no client can create innstace of object 
        private Logger()
        {
           
        }
        public void Log(string message)
        {
            Console.WriteLine(message);
        }

        // second step to make static method that can give logger instance 
        public  static Logger GetLogger()
        {
            mutex.WaitOne();
            if(_instance==null)
            {
                _count++;
                Console.WriteLine("No of Instances" + _count);
                _instance = new Logger();
            }
            mutex.ReleaseMutex();
            return _instance;
        }
    }
}
