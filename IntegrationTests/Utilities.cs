
namespace IntegrationTests
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using ODoctor.Infrastructure.Data;

    public class Utilities
    {
        public static DbContextOptions<ODoctorDbContext> TestDbContextOptions()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();
            var builder = new DbContextOptionsBuilder<ODoctorDbContext>()
                .UseInMemoryDatabase("InMemoryDb") 
                .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }
    }
}
