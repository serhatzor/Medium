namespace YieldExample
{
    public class Program
    {
        public static void Main()
        {
            IEnumerable<string> cars = GetCars(true);

            foreach (string car in cars)
            {
                Console.WriteLine(car);
            }


            IEnumerator<string> carsEnumerator = cars.GetEnumerator();

            while(carsEnumerator.MoveNext())
            {
                Console.WriteLine(carsEnumerator.Current);
            }  
        }


        public static IEnumerable<string> GetCars(bool showOnlyPremiums)
        {
            yield return GetFormattedCarName("Mercedes", "E200");
            yield return GetFormattedCarName("BMW", "520D");
            if (showOnlyPremiums)
            {
                yield break;
            }
            yield return GetFormattedCarName("Hyundai", "I20");
        }

        public static string GetFormattedCarName(string brand , string model)
        {
            return $"{model} by {brand}";
        }
    }
}


