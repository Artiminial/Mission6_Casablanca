using Microsoft.EntityFrameworkCore;

namespace Mission6_Casablanca.Models
{
    public class MovieSubmissionContext : DbContext
    {
        public MovieSubmissionContext(DbContextOptions<MovieSubmissionContext> options) : base(options)
        {
            // leave blank for now
        }
        public DbSet<Movies> Movies { get; set; }
        public DbSet<Categories> Categories { get; set; }
    }
}
