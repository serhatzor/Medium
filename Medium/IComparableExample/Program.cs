namespace IComparableExample
{
    public class Program
    {
        public static void Main()
        {

            List<Person> people = new List<Person>();

            for(int i = 0; i < 100; i++)
            {
                people.Add(new Person()
                {
                    Age = Random.Shared.Next(0,75),
                    Name = $"Name {i}",
                    LastName = $"LastName {i}"
                });
            }

            people.Sort();

            foreach (Person person in people)
            {
                Console.WriteLine($"{person.Age} -> {person.Name} {person.LastName}");
            }
        }
    }
}