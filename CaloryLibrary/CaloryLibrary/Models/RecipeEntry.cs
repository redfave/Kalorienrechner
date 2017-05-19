using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaloryLibrary.Models
{
    public class RecipeEntry
    {
        public int RecipeEntryId { get; set; }
        public DateTime Date { get; set; }

        public virtual Recipe Recipe { get; set; }
        public double Amount { get; set; }
        public virtual DiaryEntry DiaryEntry { get; set; }
    }
}
