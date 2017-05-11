using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Kalorienrechner.ViewModel.UIElements
{
    public class UserBarViewModel : BindableBase
    {
        public UserBarViewModel()
        {
            LogoutCommand = new DelegateCommand<Window>(LogoutExecute);
            AboutCommand = new DelegateCommand(AboutExecute);
        }

        public DelegateCommand<Window> LogoutCommand
        {
            get; set;
        }

        public DelegateCommand AboutCommand
        {
            get; set;
        }

        private void LogoutExecute(Window window)
        {
            Global.CurrentUserID = null;
            EntranceWindow entranceWindow = new EntranceWindow();
            entranceWindow.Show();
            window.Close();
        }

        private void AboutExecute()
        {
            AboutWindow aboutWindow = new AboutWindow();
            aboutWindow.Show();
        }
    }
}
