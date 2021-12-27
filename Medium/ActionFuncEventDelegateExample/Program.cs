using static ActionFuncEventDelegateExample.DelegateSample;

namespace ActionFuncEventDelegateExample
{
    public class Program
    {
        public static void Main()
        {
            //Delegate
            SumDelegate method = Sum;

            Console.WriteLine(method(10, 20));

            method = (new Calculator()).Sum;

            Console.WriteLine(method(10, 20));

            SimulateMemoryLeak();
        }

        public static int Sum(int num1, int num2)
        {
            return num1 + num2;
        }



        private static SumDelegate _sumMethod;
        private static WeakReference _weakReference;
        public static void SimulateMemoryLeak()
        {
            CreateCalculatorAndAssignDelegate();

            GC.Collect();

            bool isAlive = _weakReference.IsAlive;

            Console.WriteLine(isAlive);

            _sumMethod = null;

            GC.Collect();

            isAlive = _weakReference.IsAlive;

            Console.WriteLine(isAlive);

        }

        public static void CreateCalculatorAndAssignDelegate()
        {
            Calculator calculator = new Calculator();
            _weakReference = new WeakReference(calculator);

            _sumMethod = calculator.Sum;
        }
    }
}