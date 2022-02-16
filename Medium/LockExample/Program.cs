using System.Collections.Concurrent;
using System.Text;

namespace LockExample
{
    public class Program
    {
        public static void Main()
        {
            Task task1 = Task.Run(() =>
            {
                RunSimpleLockExample(1);
            });

            Task task2 = Task.Run(() =>
            {
                RunSimpleLockExample(2);
            });

            Task.WaitAll(task1, task2);

            var keys = _tracer.Keys.OrderBy(x => x);
            foreach (var key in keys)
            {
                Console.WriteLine($"{key.ToString("HH:mm:ss,fff")} -> {_tracer[key]}");
            }
        }

        private static object _lockInstance = new object();
        private static ConcurrentDictionary<DateTime, string> _tracer = new ConcurrentDictionary<DateTime, string>();
        public static void RunSimpleLockExample(int caller)
        {
            _tracer.TryAdd(DateTime.Now, $"{caller} is waiting to hold the lock");
            lock (_lockInstance)
            {
                _tracer.TryAdd(DateTime.Now, $"{caller} helded the lock");

                for (int i = 0; i < 1000000; i++)
                {
                    if (i % 100000 == 0)
                    {
                        _tracer.TryAdd(DateTime.Now, $"{caller} is running {i} index");
                    }
                }
                _tracer.TryAdd(DateTime.Now, $"{caller} is releasing the lock");
            }
        }
    }
}