
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
    public class IngredientViewModel : BindableBase
    {
        private CaloryRepository entityContext = new CaloryRepository();
        private List<Unit> _unitList;
        private Ingredient _itemContext;
        private bool _isFavorite;

        public IngredientViewModel()
        {
            SearchViewModel<Ingredient>.OnSelectedItemChanged += OnMasterSelectedItemChanged;
            UnitList = Enum.GetValues(typeof(Unit)).Cast<Unit>().ToList();
            //Prevents NullReferenceException on startup
            ItemContext = new Ingredient();
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

        public double Calories
        {
            get
            {
                return ItemContext.Calories;
            }

            set
            {
                ItemContext.Calories = value;
                RaisePropertyChanged();
            }
        }

        public double Protein
        {
            get
            {
                return ItemContext.Protein;
            }

            set
            {
                ItemContext.Protein = value;
                RaisePropertyChanged();
            }
        }

        public double Fat
        {
            get
            {
                return ItemContext.Fat;
            }

            set
            {
                ItemContext.Fat = value;
                RaisePropertyChanged();
            }
        }

        public double Carbs
        {
            get
            {
                return ItemContext.Carbs;
            }

            set
            {
                ItemContext.Carbs = value;
                RaisePropertyChanged();
            }
        }

        public List<Unit> UnitList
        {
            get
            {
                return _unitList;
            }

            private set
            {
                SetProperty(ref _unitList, value);
            }
        }

        public Unit IngredientUnit
        {
            get
            {
                return ItemContext.BaseUnit;
            }

            set
            {
                ItemContext.BaseUnit = value;
                RaisePropertyChanged();
            }
        }

        public bool IsFavorite
        {
            get
            {
                return _isFavorite;
            }
            set
            {
                SetProperty(ref _isFavorite, value);
            }
        }

        private Ingredient ItemContext
        {
            get
            {
                return _itemContext;
            }
            set
            {
                SetProperty(ref _itemContext, value);
                //Notifies all databinding sources
                RaisePropertyChanged(null);
            }
        }


        private void OnMasterSelectedItemChanged(object selectedItem)
        {
            ItemContext = selectedItem as Ingredient;
            QueryIsFavorite();
        }

        private void QueryIsFavorite()
        {
            LoginIngredientRelation loginIngredientRelation = entityContext.GetOne<LoginIngredientRelation>(filter: (f) =>
            f.Login.LoginId == Global.CurrentUserID && f.Ingredient.IngredientId == ItemContext.IngredientId);
            if (loginIngredientRelation != null)
            {
                IsFavorite = true;
            }
            else
            {
                IsFavorite = false;
            }
        }
    }
}
