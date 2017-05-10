using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaloryLibrary.Models
{
    public class Ingredient
    {
        public int IngredientId { get; set; }
        public string Name { get; set; }
        public double Calories { private get; set; }
        public double Protein { private get; set; }
        public double Fat { private get; set; }
        public double Carbs { private get; set; }
        public Unit BaseUnit { get; set; }
    }
}
