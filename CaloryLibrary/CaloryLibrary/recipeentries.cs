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
    
    public partial class recipeentries
    {
        public int RecipeEntryId { get; set; }
        public System.DateTime Date { get; set; }
        public double Amount { get; set; }
        public Nullable<int> DiaryEntry_DiaryEntryId { get; set; }
        public Nullable<int> Recipe_RecipeId { get; set; }
    
        public virtual diaryentries diaryentries { get; set; }
        public virtual recipes recipes { get; set; }
    }
}
