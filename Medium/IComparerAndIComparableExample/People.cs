namespace IComparerAndIComparableExample
{

    public class Person : IComparer<Person>
    {
        public int Compare(Person? x, Person? y)
        {
            throw new NotImplementedException();
        }
    }
}
