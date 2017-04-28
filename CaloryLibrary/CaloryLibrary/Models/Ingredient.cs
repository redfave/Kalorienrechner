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
        public virtual List<Unit> Units { get; set; }


        public double GetCalories(Unit unit)
        {
            return Calories * unit.Multiplier;
        }

        public double GetProtein(Unit unit)
        {
            return Protein * unit.Multiplier;
        }

        public double GetFat(Unit unit)
        {
            return Fat * unit.Multiplier;
        }

        public double GetCarbs(Unit unit)
        {
            return Carbs * unit.Multiplier;
        }       
    }
}
