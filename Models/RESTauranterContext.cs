using Microsoft.EntityFrameworkCore;
 
namespace RESTauranter.Models
{
    public class RESTauranterContext : DbContext
    {
        public DbSet<Reviews> reviews { get; set; }

        // base() calls the parent class' constructor passing the "options" parameter along
        public RESTauranterContext(DbContextOptions<RESTauranterContext> options) : base(options) { }
    }
}