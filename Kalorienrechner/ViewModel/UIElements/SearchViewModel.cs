using CaloryLibrary.Repository;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalorienrechner.ViewModel.UIElements
{
    public class SearchViewModel<T> : BindableBase
    {
        private CaloryRepository _entityContext = new CaloryRepository();
        private bool _showOnlyFavorites;
        private string _searchString;
        private ObservableCollection<T> _resultCollection = new ObservableCollection<T>();
        private Type _searchType;

        public SearchViewModel()
        {
            //_entityContext.Get();
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

            }
        }

        public ObservableCollection<T> ResultCollection
        {
            get
            {
                return _resultCollection;
            }
            set
            {
                _resultCollection = value;
                SetProperty(ref _resultCollection, value);
            }
        }

        public Type SearchType
        {
            get
            {
                return _searchType;
            }

            set
            {
                _searchType = value;
                SetProperty(ref _searchType, value);
            }
        }
    }

}
