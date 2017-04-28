using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaloryLibrary.Models
{
    // Favorites
    public class LoginIngredientRelation
    {
        public int LoginIngredientRelationId { get; set; }
        public virtual Ingredient Ingredient { get; set; }
        public virtual Login Login { get; set; }
    }
}
