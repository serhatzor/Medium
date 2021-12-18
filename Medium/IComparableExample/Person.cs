namespace IComparableExample
{
    public class Person : IComparable<Person>
    {
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public int Age { get; set; }

        public int CompareTo(Person? other)
        {
            if (other == null)
            {
                return 1;
            }


            if (Age > other.Age)
            {
                return 1;
            }
            else if (Age < other.Age)
            {
                return -1;
            }
            else
            {
                return Name == null ? -1 : Name.CompareTo(other.Name);
            }
        }
    }
}