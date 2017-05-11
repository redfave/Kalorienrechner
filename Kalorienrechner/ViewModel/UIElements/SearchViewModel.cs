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
        private List<QueriedType> favoritesCollection;
        private List<QueriedType> sourceCollection;
        private FavoritesTable favoriteRelationTable;
        private bool _showOnlyFavorites;
        private string _searchString;
        private ICollectionView _resultCollection;
        private QueriedType _selectedItem;

        //Source:https://web.archive.org/web/20140602140033/http://blog.danielgilbert.de/2013/12/26/simple-inter-viewmodel-communication-in-wpf/
        public delegate void SelectedItemChangedHandler(object selectedItem);
        public static event SelectedItemChangedHandler OnSelectedItemChanged = delegate { };

        public SearchViewModel(FavoritesTable favEnum)
        {
            favoriteRelationTable = favEnum;
            Reload();
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
                if (value)
                {
                    ResultCollection = CollectionViewSource.GetDefaultView(favoritesCollection);
                }
                else
                {
                    ResultCollection = CollectionViewSource.GetDefaultView(sourceCollection);
                }
                //Applies instantly the current search filter on the new collection
                SearchString = SearchString;
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
                SetSearchFilter();
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
                //Prevents NullReferenceException if no item selected
                if (value != null)
                {
                    OnSelectedItemChanged(value);
                }
            }
        }

        private void GetFavoritesCollection()
        {
            switch (favoriteRelationTable)
            {
                case FavoritesTable.Ingridient:
                    favoritesCollection = entityContext.Get<LoginIngredientRelation>(filter: (f) => f.Login.LoginId == Global.CurrentUserID).Select(s => s.Ingredient).Cast<QueriedType>().ToList();
                    break;
                case FavoritesTable.Recipe:
                    throw new NotImplementedException();
                    break;
                case FavoritesTable.Meal:
                    throw new NotImplementedException();
                    break;
                default:
                    throw new ArgumentException();
            }
        }

        private void SetSearchFilter()
        {
            switch (favoriteRelationTable)
            {
                case FavoritesTable.Ingridient:
                    {
                        ResultCollection.Filter = filter =>
                        {
                            Ingredient ingredient = filter as Ingredient;
                            return ingredient.Name.StartsWith(SearchString, StringComparison.CurrentCultureIgnoreCase);
                        };
                    }
                    break;
                case FavoritesTable.Recipe:
                    throw new NotImplementedException();
                    break;
                case FavoritesTable.Meal:
                    throw new NotImplementedException();
                    break;
                default:
                    throw new ArgumentException();
            }
        }

        private void Reload()
        {
            GetFavoritesCollection();
            sourceCollection = entityContext.GetAll<QueriedType>().ToList();
            ResultCollection = CollectionViewSource.GetDefaultView(sourceCollection);
            //Prevents NullReferenceException if the user's first interaction is to show favorite entries
            SearchString = "";
        }
    }
}
