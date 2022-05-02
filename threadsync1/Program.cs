using System;
using System.Threading;

namespace threadsync1
{
    class Program
    {
        static int count = 0;
        static object _lock = true;
        static void Main(string[] args)
        {
            Thread t1 = new Thread(CountIncrease);
            t1.Name = "t1";           
            Thread t2 = new Thread(CountDecrease);
            t2.Name = "t2";
            t1.Start();
            t2.Start();
        }

        static void CountIncrease()
        {
            while (true)
            {
                lock (_lock)
                {
                    count += 2;
                    Console.WriteLine("Thread " + Thread.CurrentThread.Name + " inreased count to " + count);
                }               
                Thread.Sleep(1000);
            }
        }

        static void CountDecrease()
        {
            while (true)
            {
                lock (_lock)
                {
                    count--;
                    Console.WriteLine("Thread " + Thread.CurrentThread.Name + " decresed count to " + count);
                }             
                Thread.Sleep(1000);
            }
        }
    }
}
