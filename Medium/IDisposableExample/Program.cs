namespace IDisposableExample;
public class Program
{
    public static void Main(string[] args)
    {
        //ReadUsersAndNotDispose();
        //InsertUserAndNotDispose();
        //Console.ReadLine();

        ReadUsersAndDispose();
        Console.WriteLine("*****");
        InserUserAndDispose();
        ReadUsersAndDispose();
        Console.WriteLine("*****");
        InserUserAndDispose();
        ReadUsersAndDispose();
        Console.WriteLine("*****");
    }

    public static void ReadUsersAndDispose()
    {
        using (UserProcessor userProcessor = new UserProcessor())
        {
            userProcessor.OpenUserProcessor(false);

            string users = userProcessor.ReadUsers();

            Console.WriteLine($"Content{Environment.NewLine}{users}");
        }
    }

    public static void InserUserAndDispose()
    {
        using (UserProcessor userProcessor = new UserProcessor())
        {
            userProcessor.OpenUserProcessor(true);

            userProcessor.InsertUser("testuser4");
        }
    }

    public static void ReadUsersAndNotDispose()
    {
        UserProcessor userProcessor = new UserProcessor();

        userProcessor.OpenUserProcessor(false);

        string users = userProcessor.ReadUsers();

        Console.WriteLine($"Content{Environment.NewLine}{users}");
    }

    public static void InsertUserAndNotDispose()
    {
        UserProcessor userProcessor = new UserProcessor();

        userProcessor.OpenUserProcessor(true);

        userProcessor.InsertUser("testuser4");
    }


}