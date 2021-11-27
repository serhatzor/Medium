namespace CheckedAndUnCheckedExample
{
    public class Program
    {
        public static void Main()
        {
            PrintBigNumber();

            checked
            {
                PrintBigNumber();
            }

            checked
            {
                int maxValueOfInt = 0;
                unchecked
                {
                    maxValueOfInt = Int32.MaxValue;
                    Console.WriteLine(maxValueOfInt);
                    maxValueOfInt++;
                    Console.WriteLine(maxValueOfInt);
                }
                maxValueOfInt = Int32.MaxValue;
                maxValueOfInt++;
            }
        }

        public static void PrintBigNumber()
        {
            int maxValueOfInt = Int32.MaxValue;
            Console.WriteLine(maxValueOfInt);
            maxValueOfInt = maxValueOfInt + 1;
            Console.WriteLine(maxValueOfInt);
        }
    }
}


