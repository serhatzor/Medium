using System.Collections.Concurrent;

namespace LockExample
{
    public class Program
    {
        public static void Main()
        {
            lock (_mainLock)
            {
                Task task1 = Task.Run(() =>
                {
                    RunSimpleLockExample(1, true);
                });

                Task task2 = Task.Run(() =>
                {
                    RunSimpleLockExample(2, false);
                });

                Task.WaitAll(task1, task2);
            }
        }
        private static object _mainLock = new Object();
        private static object _lockInstance = new object();
        public static void RunSimpleLockExample(int caller, bool doDeadLock)
        {
            Console.WriteLine($"{DateTime.Now.ToString("HH:mm:ss,fffff")} -> {caller} is waiting to hold the lock");
            lock (_lockInstance)
            {
                Console.WriteLine($"{DateTime.Now.ToString("HH:mm:ss,fffff")} -> {caller} helded the lock");
                if (doDeadLock)
                {
                    Console.WriteLine($"{DateTime.Now.ToString("HH:mm:ss,fffff")} -> {caller} is waiting to hold the main lock");
                    lock (_mainLock)
                    {

                    }
                }

                for (int i = 0; i < 1000000; i++)
                {
                    if (i % 100000 == 0)
                    {
                        Console.WriteLine($"{DateTime.Now.ToString("HH:mm:ss,fffff")} -> {caller} is running {i} index");
                    }
                }
                Console.WriteLine($"{DateTime.Now.ToString("HH:mm:ss,fffff")} -> {caller} is releasing the lock");
            }
            Console.WriteLine($"{DateTime.Now.ToString("HH:mm:ss,fffff")} -> {caller} released the lock");
        }
    }
}

