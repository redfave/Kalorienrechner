
using CaloryLibrary.Models;
using CaloryLibrary.Repository;
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
        private string _name;
        private double _calories;
        private double _protein;
        private double _fat;
        private double _carbs;
        private Unit _ingredientUnit;
        private List<Unit> _unitList;

        public IngredientViewModel ()
        {
            UnitList = entityContext.GetAll<Unit>().ToList();
        }

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                SetProperty(ref _name, value);
            }
        }

        public double Calories
        {
            get
            {
                return _calories;
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
                return _protein;
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
                return _fat;
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
                return _carbs;
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

        public int ID
        {
            get
            {
                return _ID;
            }

            private set
            {
                SetProperty(ref _ID, value);
            }
        }

        public Unit IngredientUnit
        {
            get
            {
                return _ingredientUnit;
            }

            set
            {
                SetProperty(ref _ingredientUnit, value);
            }
        }
    }
}
