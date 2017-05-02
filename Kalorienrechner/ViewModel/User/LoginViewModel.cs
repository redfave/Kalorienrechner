using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalorienrechner.ViewModel.User
{
    public class LoginViewModel : BindableBase
    {

        private DelegateCommand _loginCommand;
        private string _userName;
        private string _userPassword;

        public LoginViewModel()
        {
            LoginCommand = new DelegateCommand(ExecuteLogin, CanLogin);
        }


        public DelegateCommand LoginCommand
        {
            get
            {
                return _loginCommand;
            }

            private set
            {
                _loginCommand = value;
                SetProperty(ref _loginCommand, value);
            }
        }

        public string UserName
        {
            get
            {
                return _userName;
            }

            set
            {
                _userName = value;
                SetProperty(ref _userName, value);

            }
        }

        public string UserPassword
        {
            get
            {
                return _userPassword;
            }

            set
            {
                _userPassword = value;
                SetProperty(ref _userPassword, value);
            }
        }

        private bool CanLogin()
        {
            if (UserName != null && UserName.Count() > 0 && UserPassword != null && UserPassword.Count() > 0)
            {
                return true;
            }
            else { return false; }
        }

        private void ExecuteLogin()
        {
            //TODO
        }

    }
}
