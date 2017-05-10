using CaloryLibrary.Models;
using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaloryLibrary.DAL
{
    public class CaloryContext : DbContext
    {
        public CaloryContext() : base ("CaloryContext")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeIngredientRelation> RecipeIngredientRelations { get; set; }
        public DbSet<LoginIngredientRelation> Favorites { get; set; }
    }
}
