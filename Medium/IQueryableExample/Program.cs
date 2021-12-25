using System.Collections;
using System.Linq.Expressions;

namespace IQueryableExample
{
    public class Program
    {
        public static void Main()
        {
            People people = new People();

        }
    }

    public class Person
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
    }

    public class People : IQueryable<Person>
    {
        public Type ElementType => throw new NotImplementedException();

        public Expression Expression => new PeopleExpression();

        public IQueryProvider Provider => throw new NotImplementedException();

        public IEnumerator<Person> GetEnumerator()
        {
            return new PeopleEnumerator(null);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new PeopleEnumerator(null);
        }
    }

    public class PeopleExpression : Expression
    {
    }

    public class PeopleQueryProvider : IQueryProvider
    {
        public IQueryable CreateQuery(Expression expression)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            throw new NotImplementedException();
        }

        public object? Execute(Expression expression)
        {
            throw new NotImplementedException();
        }

        public TResult Execute<TResult>(Expression expression)
        {
            throw new NotImplementedException();
        }
    }

    public class PeopleEnumerator : IEnumerator<Person>
    {
        private readonly Person[] _people;
        private int _currentIndex = -1;
        public PeopleEnumerator(Person[] people)
        {
            _people = people;
        }

        public Person Current
        {
            get
            {
                if (_currentIndex < 0)
                    return null;
                return _people[_currentIndex];
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (_people.Length < _currentIndex)
            {
                return true;
            }
            return false;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}