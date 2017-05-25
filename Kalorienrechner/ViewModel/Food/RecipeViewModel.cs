using CaloryLibrary.Models;
using CaloryLibrary.Repository;
using Kalorienrechner.ViewModel.UIElements;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalorienrechner.ViewModel.Food
{
    public class RecipeViewModel : BindableBase
    {
        private CaloryRepository entityContext = new CaloryRepository();
        private Recipe _itemContext;

        public RecipeViewModel()
        {
            RecipeIngredients = new ObservableCollection<Ingredient>();
            SearchViewModel<Recipe>.OnSelectedItemChanged += OnSelectedItemChanged;
            //Prevents NullReferenceException on startup
            ItemContext = new Recipe();
        }

        public string Name
        {
            get
            {
                return ItemContext.Name;
            }

            set
            {
                ItemContext.Name = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<Ingredient> RecipeIngredients
        {
            get; private set;
        }

        public Recipe ItemContext
        {
            get
            {
                return _itemContext;
            }

            set
            {
                SetProperty(ref _itemContext, value);
                QueryIngriedients();
                //Notifies all databinding sources
                RaisePropertyChanged(null);
            }
        }

        private void OnSelectedItemChanged(object selectedItem)
        {
            ItemContext = selectedItem as Recipe;
        }

        private void QueryIngriedients()
        {
            RecipeIngredients.Clear();
            List<RecipeIngredientRelation> recipeIngridientIDs = entityContext.Get<RecipeIngredientRelation>().Where(w => w.Recipe.RecipeId == ItemContext.RecipeId).ToList();
            foreach (RecipeIngredientRelation relation in recipeIngridientIDs)
            {
                Ingredient indgredientToAdd = entityContext.GetOne<Ingredient>(filter: f => f.IngredientId == relation.Ingredient.IngredientId);
                RecipeIngredients.Add(indgredientToAdd);
            }
        }
    }
}
