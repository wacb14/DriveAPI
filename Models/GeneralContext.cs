using Microsoft.EntityFrameworkCore;

namespace DriveAPI.Models
{
    public class GeneralContext : DbContext
    {
        public GeneralContext(DbContextOptions<GeneralContext> options) : base(options)
        {
        }
        // Tables
        public DbSet<Filew> File { get; set; } = null;
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            // Tables' relations
            
        }
    }
}