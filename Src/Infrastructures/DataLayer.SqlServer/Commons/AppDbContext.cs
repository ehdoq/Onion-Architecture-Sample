using Domain.UserExams;
using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.SqlServer.Commons
{
    public class AppDbContext : DbContext
    {
        public DbSet<User>? Users { get; set; }
        public DbSet<UserExam>? UserExams { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            modelBuilder.Entity<UserExam>().HasQueryFilter(x => x.IsDeleted == false);

            base.OnModelCreating(modelBuilder);
        }
    }
}