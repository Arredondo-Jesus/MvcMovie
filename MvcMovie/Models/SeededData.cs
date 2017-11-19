using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<DbContextOptions<MvcMovieContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movie.AddRange(
                     new Movie
                     {
                         Title = "The Best two years",
                         ReleaseDate = DateTime.Parse("2006-1-11"),
                         Genre = "Comedy",
                         Rating = "A",
                         Price = 7.99M
                     },

                     new Movie
                     {
                         Title = "The RM ",
                         ReleaseDate = DateTime.Parse("2003-3-13"),
                         Genre = "Comedy",
                         Rating = "A",
                         Price = 8.99M
                     },

                     new Movie
                     {
                         Title = "The Other Side of Heaven",
                         ReleaseDate = DateTime.Parse("2001-2-23"),
                         Genre = "Inspirational",
                         Rating = "A",
                         Price = 9.99M
                     },

                   new Movie
                   {
                       Title = "Finding Faith in Christ",
                       ReleaseDate = DateTime.Parse("2002-4-15"),
                       Genre = "Gospel",
                       Rating = "A",
                       Price = 3.99M
                   }
                   
                );
                context.SaveChanges();
            }
        }
    }
}