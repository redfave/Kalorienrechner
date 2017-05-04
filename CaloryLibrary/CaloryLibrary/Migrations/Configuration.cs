namespace CaloryLibrary.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using CaloryLibrary;

    internal sealed class Configuration : DbMigrationsConfiguration<CaloryLibrary.DAL.CaloryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CaloryLibrary.DAL.CaloryContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            Unit[] unitsToAdd = new[]
            {
                new Unit
                {
                    Name = "1g",
                    Multiplier = 0.01,
                },
                new Unit
                {
                    Name = "100g",
                    Multiplier = 1,
                },
                new Unit
                {
                    Name = "1kg",
                    Multiplier = 10,
                }
            };
            context.Units.AddOrUpdate(
                p => p.Name,
                unitsToAdd
                );
            context.SaveChanges();

            context.Ingredients.AddOrUpdate(
              p => p.Name,
              new Ingredient
              {
                  Name = "Mehrkornbrot",
                  Calories = 229,
                  Carbs = 35,
                  Fat = 4.9,
                  Protein = 7.7,
                  Units = unitsToAdd.ToList()
              },
              new Ingredient
              {
                  Name = "Roggenvollkornbrot",
                  Calories = 196,
                  Carbs = 35.2,
                  Fat = 1.4,
                  Protein = 6.1,
                  Units = unitsToAdd.ToList()
              },
              new Ingredient
              {
                  Name = "Salami",
                  Calories = 345,
                  Carbs = 0.5,
                  Fat = 28,
                  Protein = 18,
                  Units = unitsToAdd.ToList()
              },
              new Ingredient
              {
                  Name = "Kochschinken",
                  Calories = 108,
                  Carbs = 0.9,
                  Fat = 3,
                  Protein = 19,
                  Units = unitsToAdd.ToList()
              },
              new Ingredient
              {
                  Name = "Gouda, jung",
                  Calories = 358,
                  Carbs = 0.1,
                  Fat = 29,
                  Protein = 23,
                  Units = unitsToAdd.ToList()
              },
              new Ingredient
              {
                  Name = "Emmentaler",
                  Calories = 376,
                  Carbs = 0.1,
                  Fat = 28,
                  Protein = 28,
                  Units = unitsToAdd.ToList()
              },
              new Ingredient
              {
                  Name = "Banane",
                  Calories = 93,
                  Carbs = 20,
                  Fat = 0.2,
                  Protein = 1,
                  Units = unitsToAdd.ToList()
              },
              new Ingredient
              {
                  Name = "Apfel",
                  Calories = 65,
                  Carbs = 14.4,
                  Fat = 0.1,
                  Protein = 0.3,
                  Units = unitsToAdd.ToList()
              }
            );
            context.SaveChanges();
            using (var md5 = MD5.Create())
            {
                context.Logins.AddOrUpdate(
                p => p.Name,
                new Login
                {
                    Name = "MTsu",
                    Password = Helper.CalculateMD5Hash("abc123"),
                },
                new Login
                {
                    Name = "OFalkunskyy",
                    Password = Helper.CalculateMD5Hash("blyat"),
                }
                );
            }

        }
    }
}
