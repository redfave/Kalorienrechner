
using CaloryLibrary.Models;
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
        private int _ID;
        private string _name;
        private double _calories;
        private double _protein;
        private double _fat;
        private double _carbs;
        private ObservableCollection<Unit> _units;

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

        public ObservableCollection<Unit> Units
        {
            get
            {
                return _units;
            }

        private    set
            {
                _units = value;
            }
        }

        public int ID
        {
            get
            {
                return _ID;
            }

          private  set
            {
                _ID = value;
                SetProperty(ref _ID, value);
            }
        }
    }
}
