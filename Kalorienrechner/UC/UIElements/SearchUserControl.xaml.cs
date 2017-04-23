using Kalorienrechner.ViewModel.UIElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kalorienrechner.UC.UIElements
{
    /// <summary>
    /// Interaction logic for SearchUserControl.xaml
    /// </summary>
    public partial class SearchUserControl : UserControl
    {
        private static readonly DependencyProperty QueryTypeProperty =
            DependencyProperty.Register("QueryType", typeof(Type), typeof(SearchUserControl), new PropertyMetadata(""));


        public SearchUserControl()
        {
            InitializeComponent();
            //SearchViewModel<Type> searchViewModelInstance = new SearchViewModel<Type>();
            //LayoutGrid.DataContext = searchViewModelInstance;
            Type genericContainer = typeof(SearchViewModel<>);
            Type genericType = genericContainer.MakeGenericType(typeof(this.QueryType));
            LayoutGrid.DataContext = Activator.CreateInstance();
        }

        public Type QueryType
        {
            get { return GetValue(QueryTypeProperty) as Type; }
            set { SetValue(QueryTypeProperty, value); }
        }
    }
}
