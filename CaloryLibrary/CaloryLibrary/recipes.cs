//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CaloryLibrary
{
    using System;
    using System.Collections.Generic;
    
    public partial class recipes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public recipes()
        {
            this.recipeingredientrelations = new HashSet<recipeingredientrelations>();
        }
    
        public int RecipeId { get; set; }
        public string Name { get; set; }
        public Nullable<int> Creator_LoginId { get; set; }
    
        public virtual logins logins { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<recipeingredientrelations> recipeingredientrelations { get; set; }
    }
}