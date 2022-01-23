using System.Collections;

namespace IEnumeratorAndIEnumerableExample
{
    public class Cars : IEnumerable
    {
        public List<Car> CarList = new List<Car>();

        public IEnumerator<Car> GetEnumerator()
        {
            return new CarEnumerator(CarList);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new CarEnumerator(CarList);
        }
    }

    public class CarEnumerator : IEnumerator<Car>
    {
        private int _position = -1;

        private List<Car> _cars = new List<Car>();
        public CarEnumerator(List<Car> cars)
        {
            _cars = cars;
        }

        public Car Current
        {
            get
            {
                return _cars[_position];
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return _cars[_position];
            }
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            _position++;
            if (_position >= _cars.Count)
            {
                return false;
            }
            return true;
        }

        public void Reset()
        {
            _position = -1;
        }
    }
}
