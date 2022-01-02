namespace ActionFuncEventDelegateExample
{
    public class EventSample
    {
        public static event EventHandler<EventArgs> CalculationCompleted;

        public static void RunEventExample()
        {
            CalculationCompleted += EventSample_CalculationCompleted;
            CalculationCompleted += EventSample_CalculationCompleted2;
            RunCalculate();
            Console.WriteLine("*************************************");
            CalculationCompleted -= EventSample_CalculationCompleted;
            RunCalculate();
            Console.WriteLine("*************************************");
            CalculationCompleted -= EventSample_CalculationCompleted2;
            RunCalculate();
        }

        private static void RunCalculate()
        {
            Calculator calculator = new Calculator();
            Console.WriteLine(calculator.Sum(10, 20));
            if (CalculationCompleted != null)
            {
                try
                {
                    CalculationCompleted.Invoke(null, new EventArgs());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }

            }
        }

        private static void EventSample_CalculationCompleted(object? sender, EventArgs e)
        {
            Console.WriteLine("CalculationCompleted");
            //throw new Exception();
        }

        private static void EventSample_CalculationCompleted2(object? sender, EventArgs e)
        {
            Console.WriteLine("CalculationCompleted2");
        }


        #region MemoryLeaks
        public delegate int SumAndWriteLog(int n1, int n2);
        public static event SumAndWriteLog _calculateSum;
        public static WeakReference _weakReference;
        public static void SimulateMemoryLeak()
        {
            RegisterEventWithMemoryLeak();
            GC.Collect();
            Console.WriteLine($"Our Calculator is alive {_weakReference.IsAlive}");
            _calculateSum = null;
            GC.Collect();
            Console.WriteLine($"Our Calculator is alive {_weakReference.IsAlive}");

            Console.WriteLine("****************************************");

            RegisterEventWithoutMemoryLeak();
            GC.Collect();
            Console.WriteLine($"Our Calculator is alive {_weakReference.IsAlive}");
        }

        private static void RegisterEventWithMemoryLeak()
        {
            Calculator calculator = new Calculator();
            _weakReference = new WeakReference(calculator);
            _calculateSum += calculator.SumAndWriteLog;
        }

        private static void RegisterEventWithoutMemoryLeak()
        {
            Calculator calculator = new Calculator();
            _weakReference = new WeakReference(calculator);
            _calculateSum += calculator.SumAndWriteLog;
            _calculateSum -= calculator.SumAndWriteLog;
        }
        #endregion


        #region Accessors


        public delegate int Multiply(int n1, int n2);
        public static List<Multiply> _multipliers = new List<Multiply>();
        public static event Multiply _multiplyHandler
        {
            add
            {
                if (_multipliers.Count >= 3)
                {
                    return;
                }
                _multipliers.Add(value);
            }
            remove
            {
                _multipliers.Remove(value);
            }
        }

        public static void RaiseEvents()
        {
            foreach (Multiply _multiply in _multipliers)
            {
                _multiply(10, 20);
            }
        }

        public static void SimulateCustomAccessors()
        {
            _multiplyHandler += EventSample__multiplyHandler;
            _multiplyHandler += EventSample__multiplyHandler1;
            _multiplyHandler += EventSample__multiplyHandler2;
            _multiplyHandler += EventSample__multiplyHandler3;
            RaiseEvents();
            Console.WriteLine("*******************************");
        }

        private static int EventSample__multiplyHandler(int n1, int n2)
        {
            Console.WriteLine("First Handler");
            return n1 * n2;
        }

        private static int EventSample__multiplyHandler1(int n1, int n2)
        {
            Console.WriteLine("Second Handler");
            return n1 * n2;
        }

        private static int EventSample__multiplyHandler2(int n1, int n2)
        {
            Console.WriteLine("Third Handler");
            return n1 * n2;
        }

        private static int EventSample__multiplyHandler3(int n1, int n2)
        {
            Console.WriteLine("Fourth Handler");
            return n1 * n2;
        }

        #endregion

    }
}