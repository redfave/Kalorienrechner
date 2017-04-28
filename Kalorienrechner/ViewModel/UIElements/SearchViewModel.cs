using CaloryLibrary.Models;
using CaloryLibrary.Repository;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Kalorienrechner.ViewModel.UIElements
{
    public class SearchViewModel<T> : BindableBase where T : class
    {
        private CaloryRepository _entityContext = new CaloryRepository();
        private bool _showOnlyFavorites;
        private string _searchString;
        private ICollectionView _resultCollection;

        public SearchViewModel()
        {
            ResultCollection = CollectionViewSource.GetDefaultView(_entityContext.GetAll<T>());
        }

        public bool ShowOnlyFavorites
        {
            get
            {
                return _showOnlyFavorites;
            }

            set
            {
                _showOnlyFavorites = value;
                SetProperty(ref _showOnlyFavorites, value);
            }
        }

        public string SearchString
        {
            get
            {
                return _searchString;
            }

            set
            {
                _searchString = value;
                SetProperty(ref _searchString, value);
                ResultCollection.Filter = filter =>
                {
                    Ingredient ingredient = filter as Ingredient;
                    return ingredient.Name.StartsWith(value, StringComparison.CurrentCultureIgnoreCase);
                };
            }
        }

        public ICollectionView ResultCollection
        {
            get
            {
                return _resultCollection;
            }
            private set
            {
                _resultCollection = value;
                SetProperty(ref _resultCollection, value);
            }
        }
    }

}
