using Microsoft.EntityFrameworkCore;
using PetFamily.Domain.Entities;

namespace PetFamily.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Volunteer> Volunteers => Set<Volunteer>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("");

            base.OnConfiguring(optionsBuilder);
        }
    }
}
