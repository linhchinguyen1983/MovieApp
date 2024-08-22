using Microsoft.EntityFrameworkCore;
using MovieApi.Model.DomainModel;

namespace MovieApi.Data
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Genres> Genres { get; set; }
        public DbSet<Actors> Actors { get; set; }
        public DbSet<Movies> Movies { get; set; }
        public DbSet<MovieActors> MoviesActors { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Episode> Episodes { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>().HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<MovieActors>().HasKey(x => new { x.MoviesId, x.ActorsId });
            modelBuilder.Entity<MovieGenre>().HasKey(x => new { x.MoviesId, x.GenresId });
            base.OnModelCreating(modelBuilder);

            List<Role> roles = new()
            {
                new() {
                    Id = Guid.Parse("79e41692-64f5-4789-ac63-f266f7b8ac8e"),
                    Name = "admin",
                },
                new() {
                    Id = Guid.Parse("0a1ab76c-f48f-4a5c-bb96-322f0b94328a"),
                    Name = "user",
                },
                new() {
                    Id = Guid.Parse("c005b7d5-ffc0-45a2-bd74-12a780fd9b61"),
                    Name = "vip user",
                }
            };


            modelBuilder.Entity<Role>().HasData(roles);


        }
    }
}
