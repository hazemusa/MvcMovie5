namespace MvcMovie.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MvcMovie.Models.Identity.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MvcMovie.Models.Identity.ApplicationDbContext context)
        {
            context.Movies.AddOrUpdate(i => i.Title,
                new Movie
                {
                    Title = "When Harry Met Sally",
                    ReleaseDate = DateTime.Parse("1989-1-11"),
                    Genre = "Romantic Comedy",
                    Rating = "PG",
                    Price = 7.99M,
                    movieImage = ""
                },

                 new Movie
                 {
                     Title = "Ghostbusters ",
                     ReleaseDate = DateTime.Parse("1984-3-13"),
                     Genre = "Comedy",
                     Rating = "G",
                     Price = 8.99M,
                     movieImage = ""
                 },

                 new Movie
                 {
                     Title = "Ghostbusters 2",
                     ReleaseDate = DateTime.Parse("1986-2-23"),
                     Genre = "Comedy",
                     Rating = "G",
                     Price = 9.99M,
                     movieImage = ""
                 },

               new Movie
               {
                   Title = "Rio Bravo",
                   ReleaseDate = DateTime.Parse("1959-4-15"),
                   Genre = "Western",
                   Rating = "None",
                   Price = 3.99M,
                   movieImage = ""
               },
               new Movie
               {
                   Title = "Ghost Busters III",
                   ReleaseDate = DateTime.Parse("2017-02-13"),
                   Genre = "Comedy",
                   Rating = "G",
                   Price = 3.99M,
                   movieImage = ""
               },
               new Movie
               {
                   Title = "Good Will Hunting",
                   ReleaseDate = DateTime.Parse("1997-12-05"),
                   Genre = "Drama",
                   Rating = "R",
                   Price = 3.99M,
                   movieImage = ""
               },
               new Movie
               {
                   Title = "Shrek",
                   ReleaseDate = DateTime.Parse("2001-08-22 "),
                   Genre = "Fantasy/Adventure",
                   Rating = "PG",
                   Price = 2.99M,
                   movieImage = ""
               },
                new Movie
                {
                    Title = "Space Jam",
                    ReleaseDate = DateTime.Parse("1996-11-15"),
                    Genre = "Fantasy/Science fiction",
                    Rating = "PG",
                    Price = 2.99M,
                    movieImage = ""
                }
           );

            context.Customers.AddOrUpdate(i => i.FirstName,
                new Customer
                {
                    FirstName = "Carter",
                    LastName = "Moore",
                    BirthDate = DateTime.Parse("1992-01-01"),
                    City = "St. Cloud",
                    Email = "cmoore@gmail.com",
                    Phone = "3203330000",
                    State = "MN",
                    StreetAddress = "720 4th Ave SE",
                    Zip = "56301",
                    ID = 00332125
                },
                 new Customer
                 {
                     FirstName = "Jane",
                     LastName = "Johnson",
                     BirthDate = DateTime.Parse("1994-12-05"),
                     City = "Sartell",
                     Email = "jj@hotmail.com",
                     Phone = "6153330000",
                     State = "MN",
                     StreetAddress = "190 Washington Dr",
                     Zip = "55421",
                     ID = 00332124
                 }

           );
        }
    }
}
