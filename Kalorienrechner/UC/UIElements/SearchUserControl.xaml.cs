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
        public static readonly DependencyProperty QueriedTypeProperty =
            DependencyProperty.Register("QueriedType", typeof(Type), typeof(SearchUserControl), new PropertyMetadata(string.Empty));


        public SearchUserControl()
        {
            InitializeComponent();
            Type searchViewModelType = typeof(SearchViewModel<>).MakeGenericType(new[] { QueriedType });
            LayoutGrid.DataContext = Activator.CreateInstance(searchViewModelType);

        }

        public Type QueriedType
        {
            get { return GetValue(QueriedTypeProperty) as Type; }
            set { SetValue(QueriedTypeProperty, value); }
        }
    }
}
