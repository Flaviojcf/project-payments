using Expert.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Expert.Infrastructure.Persistance
{
    public class ExpertDbContext(DbContextOptions<ExpertDbContext> options) : DbContext(options)
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<UserSkill> UserSkills { get; set; }
        public DbSet<ProjectComment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
