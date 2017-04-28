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
                    Multiplier = 1,
                },
                new Unit
                {
                    Name = "100g",
                    Multiplier = 100,
                },
                new Unit
                {
                    Name = "1kg",
                    Multiplier = 1000,
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
                  Name = "Brot",
                  Calories = 300,
                  Carbs = 25,
                  Fat = 5,
                  Protein = 5,
                  Units = unitsToAdd.ToList()
              },
              new Ingredient
              {
                  Name = "Wurst",
                  Calories = 150,
                  Carbs = 10,
                  Fat = 20,
                  Protein = 10,
                  Units = unitsToAdd.ToList()
              },
              new Ingredient
              {
                  Name = "Käse",
                  Calories = 250,
                  Carbs = 15,
                  Fat = 30,
                  Protein = 20,
                  Units = unitsToAdd.ToList()
              }
            );
            context.SaveChanges();
            using (var md5 = MD5.Create())
            {
                context.Logins.AddOrUpdate(
                p => p.LoginId,
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
