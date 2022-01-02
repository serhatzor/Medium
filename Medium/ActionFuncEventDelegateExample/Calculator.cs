namespace ActionFuncEventDelegateExample
{
    public class Calculator
    {
        public int Sum(int num1, int num2)
        {
            return num1 + num2;
        }

        public int SumAndWriteLog(int num1, int num2)
        {
            int result = num1 + num2;
            Console.WriteLine(result);
            return result;
        }

    }
}