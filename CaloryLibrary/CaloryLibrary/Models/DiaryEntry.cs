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
        public double Amount { get; set; }
        public DateTime Date { get; set; }

        public virtual Login Creator { get; set; }
        public virtual Ingredient Ingredient { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}
