using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaloryLibrary.Models
{
    public class DiaryEntry
    {
        public int DiaryEntryId { get; set; }
        public Mealtime Mealtime { get; set; }
        public virtual Login Creator { get; set; }
        public virtual List<IngredientEntry> IngredientEntries { get; set; }
        public virtual List<RecipeEntry> RecipeEntries { get; set; }
    }
}
