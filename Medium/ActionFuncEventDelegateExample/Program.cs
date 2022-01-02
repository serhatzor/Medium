
namespace ActionFuncEventDelegateExample
{
    public class Program
    {
        public static void Main()
        {
            //DelegateSample.RunDelegateExample();
            EventSample.RunEventExample();
            EventSample.SimulateMemoryLeak();
            EventSample.SimulateCustomAccessors();
        }
    }
}