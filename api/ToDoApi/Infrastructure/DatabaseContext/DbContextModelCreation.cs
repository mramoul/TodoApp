using ToDoApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Task = ToDoApi.Domain.Entities.Task;

namespace ToDoApi.Infrastructure.DataBaseContext
{
    public partial class ApplicationDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureTask(modelBuilder);
            ConfigureUser(modelBuilder);
        }

        private static void ConfigureTask(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>()
                .HasOne(a => a.AssignedUser)
                .WithMany(b => b.Tasks)
                .HasForeignKey("UserId")
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Task>()
                .Navigation(a => a.AssignedUser)
                .AutoInclude();
        }

        private static void ConfigureUser(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(b => b.Tasks)
                .WithOne(a => a.AssignedUser)
                .HasForeignKey("UserId")
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
                .Navigation(b => b.Tasks)
                .AutoInclude();
        }

    }
}