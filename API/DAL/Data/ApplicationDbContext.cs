using BLL.Data;
using BLL.Helpers;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<User>()
                .HasIndex(a => a.Email)
                .IsUnique();

            modelBuilder.Entity<User>().HasData(new User { Id = Guid.NewGuid(), Username = "admin", Email = "admin@support.org", Password = PasswordHelper.PasswordHash("password", "admin@support.org"), UserType = UserEnumType.Staff });
            modelBuilder.Entity<User>().HasData(new User { Id = Guid.NewGuid(), Username = "userone", Email = "userone@support.org", Password = PasswordHelper.PasswordHash("password", "userone@support.org"), UserType = UserEnumType.Staff });
            modelBuilder.Entity<User>().HasData(new User { Id = Guid.NewGuid(), Username = "usertwo", Email = "usertwo@support.org", Password = PasswordHelper.PasswordHash("password", "usertwo@support.org"), UserType = UserEnumType.Staff });
            modelBuilder.Entity<User>().HasData(new User { Id = Guid.NewGuid(), Username = "customerone", Email = "customerone@customer.org", Password = PasswordHelper.PasswordHash("password", "customerone@customer.org"), UserType = UserEnumType.Customer });
            modelBuilder.Entity<User>().HasData(new User { Id = Guid.NewGuid(), Username = "customertwo", Email = "customertwo@customer.org", Password = PasswordHelper.PasswordHash("password", "customertwo@customer.org"), UserType = UserEnumType.Customer });
        }

        public DbSet<User> Users { get; set; } = default!;
        public DbSet<Answer> Answers { get; set; } = default!;
        public DbSet<Ticket> Tickets { get; set; } = default!;
    }
}
