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
    public class SearchViewModel<QueriedType, QueriedTypeUserRelation> : BindableBase
        where QueriedType : class
        where QueriedTypeUserRelation : class

    {
        private CaloryRepository entityContext = new CaloryRepository();
        private List<QueriedTypeUserRelation> favoritesCollection;
        private bool _showOnlyFavorites;
        private string _searchString;
        private ICollectionView _resultCollection;
        private QueriedType _selectedItem;

        //Source:https://web.archive.org/web/20140602140033/http://blog.danielgilbert.de/2013/12/26/simple-inter-viewmodel-communication-in-wpf/
        public delegate void SelectedItemChangedHandler(object selectedItem);
        public static event SelectedItemChangedHandler OnSelectedItemChanged = delegate { };

        public SearchViewModel()
        {
            ResultCollection = CollectionViewSource.GetDefaultView(entityContext.GetAll<QueriedType>());
            //favoritesCollection = entityContext.GetAll<QueriedTypeUserRelation>().ToList();
            //var list = favoritesCollection.Select(s => s[0]);
            var test = entityContext.Get<LoginIngredientRelation>(filter: ).ToList();
            List<int> test2 = test.Select(s => s.Ingredient.IngredientId).ToList();
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
    }

}
