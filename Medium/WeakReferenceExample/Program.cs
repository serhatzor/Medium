namespace WeakReferenceExample
{
    public class CustomWindow
    {
        public string WindowName { get; set; }

        public void OnProgramClosed(object? sender, EventArgs e)
        {
            Console.WriteLine($"{WindowName} is detected that the program is closed");
        }
    }

    public class Program
    {
        public static event EventHandler<EventArgs> ProgramClosed;
        static CustomWindow? _tempWindow;

        public static void Main()
        {
            Console.WriteLine("Demo0 is running");
            SimulateDemo0();

            Console.WriteLine();

            Console.WriteLine("Demo1 is running"); 
            SimulateDemo1();

            Console.WriteLine();

            Console.WriteLine("Demo2 is running");
            SimulateDemo2();

            ProgramClosed?.Invoke(null, EventArgs.Empty);
        }

        #region demo0

        public static void SimulateDemo0()
        {
            NoMemoryLeak();
            while (true)
            {
                Console.Write("Command: ");
                string command = Console.ReadLine();
                switch (command)
                {
                    case "quit":
                        return;
                    case "find":
                        Console.WriteLine(MemorLeakTracer.FindSuspectedMemoryLeaks());
                        break;
                }
            }
        }
        public static void NoMemoryLeak()
        {
            CustomWindow window = new CustomWindow() { WindowName = "NoMemoryLeak Window" };
            MemorLeakTracer.AddObject(window);
            Console.WriteLine($"{window.WindowName} has been created.");

            MemorLeakTracer.SetAsDone(window);
        }

        #endregion

        #region demo1

        public static void SimulateDemo1()
        {
            CauseAMemoryLeakByReferenceCount();
            while (true)
            {
                Console.Write("Command: ");
                string command = Console.ReadLine();
                switch (command)
                {
                    case "quit":
                        return;
                    case "find":
                        Console.WriteLine(MemorLeakTracer.FindSuspectedMemoryLeaks());
                        break;
                    case "fix":
                        _tempWindow = null;
                        break;

                }
            }
        }
        public static void CauseAMemoryLeakByReferenceCount()
        {
            CustomWindow window = new CustomWindow() { WindowName = "CauseAMemoryLeakByReferenceCount Window" };
            MemorLeakTracer.AddObject(window);
            Console.WriteLine($"{window.WindowName} has been created.");

            //Causes a leakage
            _tempWindow = window;

            MemorLeakTracer.SetAsDone(window);
        }

        #endregion

        #region demo2

        public static void SimulateDemo2()
        {
            CauseAMemoryLeakByRegisteredEvent();
            bool run = true;
            while (run)
            {
                Console.Write("Command: ");
                string command = Console.ReadLine();
                switch (command)
                {
                    case "quit":
                        run = false;
                        break;
                    case "find":
                        Console.WriteLine(MemorLeakTracer.FindSuspectedMemoryLeaks());
                        break;
                    case "fix":
                        ProgramClosed = null;
                        break;
                }
            }

            Console.WriteLine();
            NoMemoryLeakByUnRegisteredEvent();
            while (true)
            {
                Console.Write("Command: ");
                string command = Console.ReadLine();
                switch (command)
                {
                    case "quit":
                        return;
                    case "find":
                        Console.WriteLine(MemorLeakTracer.FindSuspectedMemoryLeaks());
                        break;
                }
            }
        }
        public static void CauseAMemoryLeakByRegisteredEvent()
        {
            CustomWindow window = new CustomWindow() { WindowName = "CauseAMemoryLeakByRegisteredEvent Window" };
            MemorLeakTracer.AddObject(window);
            Console.WriteLine($"{window.WindowName} has been created.");

            //Causes a leakage
            ProgramClosed += window.OnProgramClosed;

            MemorLeakTracer.SetAsDone(window);
        }

        public static void NoMemoryLeakByUnRegisteredEvent()
        {
            CustomWindow window = new CustomWindow() { WindowName = "NoMemoryLeakByUnRegisteredEvent Window" };
            MemorLeakTracer.AddObject(window);
            Console.WriteLine($"{window.WindowName} has been created.");

            //Causes a leakage
            ProgramClosed += window.OnProgramClosed;

            MemorLeakTracer.SetAsDone(window);

            ProgramClosed -= window.OnProgramClosed;
        }



        #endregion
    }
}