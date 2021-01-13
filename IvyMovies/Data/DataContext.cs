using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IvyMovies.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace IvyMovies.Data
{
    public class DataContext : IdentityDbContext<IdentityUser>
    {
        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public object Movie { get; internal set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Movie>()
                .HasMany<Actor>(m => m.Actors)
                .WithOne(a => a.Movie)
                .HasForeignKey(s => s.MovieId);

            modelBuilder.Entity<Movie>()
                .HasMany<Director>(m => m.Directors)
                .WithOne(a => a.Movie)
                .HasForeignKey(s => s.MovieId);

            modelBuilder.Entity<Movie>()
                .HasMany<Genre>(m => m.Genres)
                .WithOne(a => a.Movie)
                .HasForeignKey(s => s.MovieId);

            modelBuilder.Entity<Movie>()
                .HasData(
                new Movie
                {
                    MovieId = 1,
                    MovieName = "TestFilm1",
                },
                new Movie
                {
                    MovieId = 2,
                    MovieName = "TestFilm2"
                },
                new Movie
                {
                    MovieId = 3,
                    MovieName = "TestFilm3"
                }
                );
            modelBuilder.Entity<Actor>()
                .HasData(
                new Actor
                {
                    ActorId = 1,
                    ActorName = "TestAkter1",
                    MovieId = 3
                },
                new Actor
                {
                    ActorId = 2,
                    ActorName = "TestAkter2",
                    MovieId = 2
                },
                new Actor
                {
                    ActorId = 3,
                    ActorName = "TestAkter3",
                    MovieId = 1
                }
                );
            modelBuilder.Entity<Director>()
                .HasData(
                new Director
                {
                    DirectorId = 1,
                    DirectorName = "TestReziser1",
                    MovieId = 3,
                },
                new Director
                {
                    DirectorId = 2,
                    DirectorName = "TestReziser2",
                    MovieId = 2,
                },
                new Director
                {
                    DirectorId = 3,
                    DirectorName = "TestReziser3",
                    MovieId = 1,
                }
                );
            modelBuilder.Entity<Genre>()
                .HasData(
                new Genre
                {
                    GenreId = 1,
                    GenreName = "TestZanr1",
                    MovieId = 3,
                },
                new Genre
                {
                    GenreId = 2,
                    GenreName = "TestZanr3",
                    MovieId = 2,
                },
                new Genre
                {
                    GenreId = 3,
                    GenreName = "TestZanr3",
                    MovieId = 1,
                }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
