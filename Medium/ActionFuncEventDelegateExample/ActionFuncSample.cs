namespace ActionFuncEventDelegateExample
{
    public class ActionFuncSample
    {
        public static void RunActionSample()
        {
            Action<int, int> sumAndShowOnConsole = new Action<int, int>(Sum);
            sumAndShowOnConsole(10, 20);
        }

        public static void Sum(int number1, int number2)
        {
            Console.WriteLine(number1 + number2);
        }

        public static void RunFuncSample()
        {
            Func<int> generateRandomFunc = new Func<int>(GenerateRandomFunc);

            Console.WriteLine(generateRandomFunc());

            Func<int, int, string> sumFunc = new Func<int, int, string>(SumAsStringFunc);
            string sum = sumFunc(12, 24);
            Console.WriteLine(sum);
        }

        public static int GenerateRandomFunc()
        {
            return Random.Shared.Next();
        }

        public static string SumAsStringFunc(int number1, int number2)
        {
            return (number1 + number2).ToString();
        }

        public static void RunArrowFunction()
        {
            Action<int> showAgeAction = (age) =>
            {
                Console.WriteLine($"The person is {age} years old");
            };

            showAgeAction(10);

            Func<int, int, int> sumFunc = (number1, number2) =>
            {
                return number1 + number2;
            };

            int sum = sumFunc(12, 36);

            Console.WriteLine(sum);
        }

        public class Person
        {
            public int Age { get; set; }
        }
        private static Action showPersonInfo;
        private static WeakReference weakReferenceForPerson1;
        private static WeakReference weakReferenceForPerson2;
        private static WeakReference weakReferenceForPerson3;
        public static void RunClosureExample()
        {
            Person person1 = new Person() { Age = 18 };
            weakReferenceForPerson1 = new WeakReference(person1);

            Person person2 = new Person() { Age = 25 };
            weakReferenceForPerson2 = new WeakReference(person2);

            Person person3 = new Person() { Age = 40 };
            weakReferenceForPerson3 = new WeakReference(person3);

            showPersonInfo = () =>
            {
                Console.WriteLine($"Person 1 age is {person1.Age}");
                Console.WriteLine($"Person 2 age is {person2.Age}");
            };
        }

        public static void RunScopedParamExample()
        {
            GC.Collect();

            Console.WriteLine($"Person 1 is Alive={weakReferenceForPerson1.IsAlive}");
            Console.WriteLine($"Person 2 is Alive={weakReferenceForPerson2.IsAlive}");
            Console.WriteLine($"Person 3 is Alive={weakReferenceForPerson3.IsAlive}");

            showPersonInfo();

            Console.WriteLine($"Person 1 is Alive={weakReferenceForPerson1.IsAlive}");
            Console.WriteLine($"Person 2 is Alive={weakReferenceForPerson2.IsAlive}");
            Console.WriteLine($"Person 3 is Alive={weakReferenceForPerson3.IsAlive}");
        }


        public static void RunForAndForEachSample()
        {
            List<Person> people = new List<Person>();

            people.Add(new Person() { Age = 43 });
            people.Add(new Person() { Age = 44 });
            people.Add(new Person() { Age = 45 });
            people.Add(new Person() { Age = 46 });

            List<Action> showPersonInfoActions = new List<Action>();

            for (int i = 0; i < people.Count(); i++)
            {
                int tempIndex = i;
                showPersonInfoActions.Add(() =>
                {
                    Console.WriteLine($"i = {i}");
                    Console.WriteLine($"tempIndex = {tempIndex}");
                    Console.WriteLine($"The person in for is {people[i].Age} years old");

                });
            }

            foreach (Action act in showPersonInfoActions)
            {
                try
                {
                    act();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}