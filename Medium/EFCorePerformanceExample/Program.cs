namespace EFCorePerformanceExample;
public class Program
{
    public static void Main(string[] args)
    {
        InitDb();
    }

    public static void InitDb()
    {
        using (ECommerceDbContext dbContext = new ECommerceDbContext())
        {
            dbContext.Database.EnsureCreated();
            dbContext.Database.Migrate();
            dbContext.SaveChanges();
        }

        using (ECommerceDbContext dbContext = new ECommerceDbContext())
        {
            for (int i = 0; i <= 99; i++)
            {
                List<Product> products = new List<Product>();
                for (int j = 0; j <= 100; j++)
                {
                    products.Add(new Product()
                    {
                        Id = Guid.NewGuid(),
                        Name = $"Product {i} - {j}",
                        Description = $"Product {i} - {j} description",
                        Price = j * 10
                    });
                }

                dbContext.ProductCategories.Add(new ProductCategory()
                {
                    Id = Guid.NewGuid(),
                    Name = $"Category {i}",
                    Description = $"Category {i} description",
                    Products = products
                });
            }

            dbContext.SaveChanges();
        }
    }
}
