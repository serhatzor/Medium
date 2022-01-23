namespace IDisposableExample;
public class Program
{
    public static void Main(string[] args)
    {
        ReadUsers();
        InsertUser();
        ReadUsers();
        Console.ReadLine();
    }

    public static void ReadUsers()
    {
        UserProcessor userProcessor = new UserProcessor();

        userProcessor.OpenUserProcessor(false);

        string users = userProcessor.ReadUsers();

        Console.WriteLine($"Content{Environment.NewLine}{users}");
    }

    public static void InsertUser()
    {
        UserProcessor userProcessor = new UserProcessor();

        userProcessor.OpenUserProcessor(true);

        userProcessor.InsertUser("testuser4");
    }
}