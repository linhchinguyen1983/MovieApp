using Microsoft.EntityFrameworkCore;

namespace MovieApp.Data
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }


    }
}
