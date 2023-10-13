using HeladoApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace HeladoApi
{
    public class IceCreamContext : DbContext
    {
        public IceCreamContext(DbContextOptions<IceCreamContext> dbContextOptions) : base(dbContextOptions)
        {
            try
            {
                var databaseCreater = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                if (databaseCreater != null)
                {
                    if (!databaseCreater.CanConnect()) { databaseCreater.Create(); }
                    if (!databaseCreater.HasTables()) { databaseCreater.CreateTables(); }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public DbSet<IceCream> IceCreams { get; set; }
    }
}
