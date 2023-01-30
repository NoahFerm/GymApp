using Gym.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Gym.Data.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<GymClass> GymClasses => Set<GymClass>();
        public DbSet<ApplicationUserGymClass> ApplicationUserGymClass => Set<ApplicationUserGymClass>();

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<ApplicationUser>().Property<DateTime>("TimeOfRegistration");
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUserGymClass>().HasKey(a => new { a.ApplicationUserId, a.GymClassId });
        
            builder.Entity<GymClass>().HasQueryFilter(g => g.StartTime > DateTime.UtcNow);
        }

        //public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        //{
        //    foreach (var entry in ChangeTracker.Entries<ApplicationUser>().Where(e => e.State == EntityState.Added))
        //    {
        //        entry.Property("TimeOfRegistration").CurrentValue = DateTime.Now;
        //    }
        //    return base.SaveChangesAsync(cancellationToken);
        //}
    }
}