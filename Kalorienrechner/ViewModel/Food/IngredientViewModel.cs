
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
                ItemContext.BaseUnit = value;
                RaisePropertyChanged();
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
