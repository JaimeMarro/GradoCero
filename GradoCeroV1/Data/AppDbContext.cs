using GradoCeroV1.Models;
using Microsoft.EntityFrameworkCore;

namespace GradoCeroV1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Alabanza> Alabanzas { get; set; }
    }
}