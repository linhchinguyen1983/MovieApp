using Microsoft.EntityFrameworkCore;
using MovieApi.Model.DomainModel;

namespace MovieApi.Data
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>().HasKey(x => new { x.UserId , x.RoleId});
            base.OnModelCreating(modelBuilder);

            List<Role> roles = new List<Role>()
            {
                new Role
                {
                    Id = Guid.Parse("79e41692-64f5-4789-ac63-f266f7b8ac8e"),
                    Name = "reader",
                },
                new Role
                {
                    Id = Guid.Parse("0a1ab76c-f48f-4a5c-bb96-322f0b94328a"),
                    Name = "writer",
                }
            };

            modelBuilder.Entity<Role>().HasData(roles);
        }
    }
}
