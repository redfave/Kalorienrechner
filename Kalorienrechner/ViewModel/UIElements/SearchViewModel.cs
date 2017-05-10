using CaloryLibrary.Models;
using CaloryLibrary.Repository;
using Kalorienrechner.Helper.Enum;
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
    public class SearchViewModel<QueriedType> : BindableBase
        where QueriedType : class

    {
        private CaloryRepository entityContext = new CaloryRepository();
        private List<object> favoritesCollection;
        private bool _showOnlyFavorites;
        private string _searchString;
        private ICollectionView _resultCollection;
        private QueriedType _selectedItem;

        //Source:https://web.archive.org/web/20140602140033/http://blog.danielgilbert.de/2013/12/26/simple-inter-viewmodel-communication-in-wpf/
        public delegate void SelectedItemChangedHandler(object selectedItem);
        public static event SelectedItemChangedHandler OnSelectedItemChanged = delegate { };

        public SearchViewModel(FavoritesTable favEnum)
        {
            SetFavoritesCollection(favEnum);
            ResultCollection = CollectionViewSource.GetDefaultView(entityContext.GetAll<QueriedType>());
            //favoritesCollection = entityContext.GetAll<QueriedTypeUserRelation>().ToList();
            //var list = favoritesCollection.Select(s => s[0]);

        }

        public bool ShowOnlyFavorites
        {
            get
            {
                return _showOnlyFavorites;
            }

            set
            {
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
                SetProperty(ref _searchString, value);
                SetCollectionFilter();
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
                SetProperty(ref _resultCollection, value);
            }
        }

        public QueriedType SelectedItem
        {
            get
            {
                return _selectedItem;
            }

            set
            {
                SetProperty(ref _selectedItem, value);
                OnSelectedItemChanged(value);
            }
        }

        private void SetFavoritesCollection(FavoritesTable favEnum)
        {
            switch (favEnum)
            {
                case FavoritesTable.Ingridient:
                    favoritesCollection = entityContext.Get<LoginIngredientRelation>(filter: (f) => f.Login.LoginId == Global.CurrentUserID).Cast<object>().ToList();
                    break;
                case FavoritesTable.Recipe:
                    throw new NotImplementedException();
                case FavoritesTable.Meal:
                    throw new NotImplementedException();
                default:
                    throw new ArgumentException();
            }
        }

        private void SetCollectionFilter()
        {
            if (ShowOnlyFavorites)
            {
                ResultCollection.Filter = filter =>
                {
                    Ingredient ingredient = filter as Ingredient;
                    //TODO
                    return ingredient.Name.StartsWith(SearchString, StringComparison.CurrentCultureIgnoreCase);
                };
            }
            else
            {
                ResultCollection.Filter = filter =>
                {
                    Ingredient ingredient = filter as Ingredient;
                    return ingredient.Name.StartsWith(SearchString, StringComparison.CurrentCultureIgnoreCase);
                };
            }
        }
    }
}
