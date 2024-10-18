using Microsoft.EntityFrameworkCore;
using Practice_Identity_and_Data_Protection.Entities;

namespace Practice_Identity_and_Data_Protection.Context
{
    public class CustomIdentityDbContext : DbContext
    {
        public CustomIdentityDbContext(DbContextOptions<CustomIdentityDbContext> options) : base(options)
        {
            
        }

        public DbSet<UserEntity> Users => Set<UserEntity>();
    }
}
