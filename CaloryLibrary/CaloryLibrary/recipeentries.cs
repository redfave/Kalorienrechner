//------------------------------------------------------------------------------
// <auto-generated>
//     Der Code wurde von einer Vorlage generiert.
//
//     Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten der Anwendung.
//     Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
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