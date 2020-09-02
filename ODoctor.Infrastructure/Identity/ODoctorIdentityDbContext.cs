using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ODoctor.Infrastructure.Identity
{
    public class ODoctorIdentityDbContext: IdentityDbContext<ODoctorUser>
    {
        public ODoctorIdentityDbContext(DbContextOptions<ODoctorIdentityDbContext> options):
            base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityUser>(t => t.ToTable("Users"));
            builder.Entity<IdentityUserClaim<int>>(t => t.ToTable("UserClaims"));
            builder.Entity<IdentityUserLogin<int>>(t =>
            {
                t.HasKey(t => t.UserId);
                t.ToTable("UserLogin");
            });
            builder.Entity<IdentityRole<int>>(t => t.ToTable("Roles"));
            builder.Entity<IdentityRoleClaim<int>>(t => t.ToTable("RoleClaims"));
            builder.Entity<IdentityUserRole<int>>(t =>
            {
                t.HasKey(t => new { t.RoleId, t.UserId });
                t.ToTable("UserRoles");
            });
        }
    }

    public class ODoctorIdentityDbContextFactory: IDesignTimeDbContextFactory<ODoctorIdentityDbContext>
    {
        public ODoctorIdentityDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ODoctorIdentityDbContext>();
            optionsBuilder.UseSqlServer("Server=VINCENT-PC\\SQLEXPRESS;Database=ODoctorIdentityDb;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new ODoctorIdentityDbContext(optionsBuilder.Options);
        }
    }
}
