
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
        private int _ID;
        private double _calories;
        private double _protein;
        private double _fat;
        private double _carbs;
        private Unit _ingredientUnit;
        private List<Unit> _unitList;
        private Ingredient _itemContext;

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
                SetProperty(ref _calories, value);

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
                SetProperty(ref _protein, value);
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
                SetProperty(ref _fat, value);
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
                SetProperty(ref _carbs, value);
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

        //public int ID
        //{
        //    get
        //    {
        //        return ItemContext.IngredientId;
        //    }

        //    private set
        //    {
        //        SetProperty(ref _ID, value);
        //    }
        //}

        public Unit IngredientUnit
        {
            get
            {
               return ItemContext.BaseUnit;
            }

            set
            {
                SetProperty(ref _ingredientUnit, value);
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

        public void OnMasterSelectedItemChanged(object selectedItem)
        {
            ItemContext = selectedItem as Ingredient;
        }

    }
}
