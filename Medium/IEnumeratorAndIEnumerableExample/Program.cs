using IEnumeratorAndIEnumerableExample;
using System.Collections;

namespace CheckedAndUnCheckedExample
{
    public class Program
    {
        public static void Main()
        {
            Cars cars = new Cars();
            cars.CarList.Add(new Car() { Brand = "BMW", Id = 1, Model = "520", Name = "BMW 520" });
            cars.CarList.Add(new Car() { Brand = "Opel", Id = 2, Model = "Astra", Name = "Opel Astra" });
            cars.CarList.Add(new Car() { Brand = "Hyundai", Id = 3, Model = "Tucson", Name = "Hyundai Tucson" });
            cars.CarList.Add(new Car() { Brand = "Mercedes", Id = 4, Model = "C200", Name = "Mercedes C200" });

            foreach (Car car in cars)
            {

                Console.WriteLine($"{car.Id} -> {car.Name}");
            }

            IEnumerable carsAsObject = cars;
            foreach (var car in carsAsObject)
            {
                Car castedCar = (Car)car;
                Console.WriteLine($"{castedCar.Id} -> {castedCar.Name}");
            }

        }

    }
}