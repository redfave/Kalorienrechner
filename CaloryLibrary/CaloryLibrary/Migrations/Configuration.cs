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

            Ingredient[] ingredientsToAdd = new[]
            {
                new Ingredient
              {
                  Name = "Mehrkornbrot",
                  Calories = 229,
                  Carbs = 35,
                  Fat = 4.9,
                  Protein = 7.7,
                  BaseUnit = Unit.Gram,
              },
              new Ingredient
              {
                  Name = "Roggenvollkornbrot",
                  Calories = 196,
                  Carbs = 35.2,
                  Fat = 1.4,
                  Protein = 6.1,
                  BaseUnit = Unit.Gram,
              },
              new Ingredient
              {
                  Name = "Salami",
                  Calories = 345,
                  Carbs = 0.5,
                  Fat = 28,
                  Protein = 18,
                  BaseUnit = Unit.Gram,
              },
              new Ingredient
              {
                  Name = "Kochschinken",
                  Calories = 108,
                  Carbs = 0.9,
                  Fat = 3,
                  Protein = 19,
                  BaseUnit = Unit.Gram,
              },
              new Ingredient
              {
                  Name = "Gouda, jung",
                  Calories = 358,
                  Carbs = 0.1,
                  Fat = 29,
                  Protein = 23,
                  BaseUnit = Unit.Gram,
              },
              new Ingredient
              {
                  Name = "Emmentaler",
                  Calories = 376,
                  Carbs = 0.1,
                  Fat = 28,
                  Protein = 28,
                  BaseUnit = Unit.Gram,
              },
              new Ingredient
              {
                  Name = "Banane",
                  Calories = 93,
                  Carbs = 20,
                  Fat = 0.2,
                  Protein = 1,
                  BaseUnit = Unit.Gram,
              },
              new Ingredient
              {
                  Name = "Apfel",
                  Calories = 65,
                  Carbs = 14.4,
                  Fat = 0.1,
                  Protein = 0.3,
                  BaseUnit = Unit.Gram,
              },
              new Ingredient
              {
                  Name = "Vollmilch",
                  Calories = 65,
                  Carbs = 4.7,
                  Fat = 3.5,
                  Protein = 3.4,
                  BaseUnit = Unit.Milliliter,
              },
              new Ingredient
              {
                  Name = "Orangensaft",
                  Calories = 44,
                  Carbs = 9.7,
                  Fat = 0.2,
                  Protein = 0.7,
                  BaseUnit = Unit.Milliliter,
              }
            };

            context.Ingredients.AddOrUpdate(
              p => p.Name,
              ingredientsToAdd
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
            context.SaveChanges();

            LoginIngredientRelation[] loginIngredientRelationsToAdd = new[]
           {                new LoginIngredientRelation
                {
                    Login = context.Logins.Where(w => w.LoginId == 2).Single(),
                    Ingredient = context.Ingredients.Where(w => w.IngredientId == 3).Single()
                },
                                new LoginIngredientRelation
                {
                    Login = context.Logins.Where(w => w.LoginId == 2).Single(),
                    Ingredient = context.Ingredients.Where(w => w.IngredientId == 6).Single()
                },
                                                new LoginIngredientRelation
                {
                    Login = context.Logins.Where(w => w.LoginId == 2).Single(),
                    Ingredient = context.Ingredients.Where(w => w.IngredientId == 8).Single()
                }
            };
            context.Favorites.AddOrUpdate(loginIngredientRelationsToAdd);
            context.SaveChanges();
        }
    }
}
