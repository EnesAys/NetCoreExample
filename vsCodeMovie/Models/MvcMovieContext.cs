using Microsoft.EntityFrameworkCore;  
  
namespace vsCodeMovie.Models  
{  
    public class MvcMovieContext : DbContext  
    {  
        public MvcMovieContext (DbContextOptions<MvcMovieContext> options)  
            : base(options)  
        {  
        }  
  
        public DbSet<vsCodeMovie.Models.Movie> Movie { get; set; }  
    }  
} 