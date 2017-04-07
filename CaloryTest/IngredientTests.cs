using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CaloryLibrary.Repository;
using CaloryLibrary.Models;

namespace CaloryTest
{
    [TestClass]
    public class IngredientTests
    {
        [TestMethod]
        public void RepoAvailableTest()
        {
            CaloryRepository repo = new CaloryRepository();
            Assert.IsNotNull(repo);
        }

        [TestMethod]
        public void CreateTest()
        {
            CaloryRepository repo = new CaloryRepository();
            Ingredient newIngredient = new Ingredient()
            {
                Name = "UnitTestIngredient",
                Calories = 0.5,
                Carbs = 0.2,
                Fat = 0.05,
                Protein = 0.1,
            };

            repo.Create(newIngredient);
            repo.Save();

            Ingredient repoIngredient = repo.GetOne<Ingredient>(m => m.Name == "UnitTestIngredient");
            Assert.AreEqual(newIngredient, repoIngredient);
        }
    }
}
