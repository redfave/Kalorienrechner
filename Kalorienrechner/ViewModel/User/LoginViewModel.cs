﻿using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using CaloryLibrary.Repository;
using CaloryLibrary.Models;
using System.Windows.Controls;
using System.Windows;

namespace Kalorienrechner.ViewModel.User
{
    public class LoginViewModel : BindableBase
    {
        private DelegateCommand<PasswordBox> _loginCommand;
        private string _userName;
        private bool _displayWrongCredentialsError;
        private bool _isBusy;
        private MD5 md5;
        private CaloryRepository repo = new CaloryRepository();

        public LoginViewModel()
        {
            LoginCommand = new DelegateCommand<PasswordBox>(ExecuteLogin, CanLogin);
            md5 = MD5.Create();
        }

        public DelegateCommand<PasswordBox> LoginCommand
        {
            get
            {
                return _loginCommand;
            }

            private set
            {
                _loginCommand = value;
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
                SetProperty(ref _userName, value);
                RaiseLoginCommandCanExecuteChanged();
            }
        }

        public bool DisplayWrongCredentialsError
        {
            get
            {
                return _displayWrongCredentialsError;
            }

            private set
            {
                SetProperty(ref _displayWrongCredentialsError, value);
            }
        }

        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }

            set
            {
                SetProperty(ref _isBusy, value);
            }
        }

        private bool CanLogin(PasswordBox parameter)
        {
            if (parameter == null)
            {
                throw new ArgumentNullException();
            }
            if (UserName != null && UserName.Count() > 0 && parameter.Password != null && parameter.Password.Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            };
        }

        private void ExecuteLogin(PasswordBox parameter)
        {
            if (parameter == null)
            {
                throw new ArgumentNullException();
            }
            IsBusy = true;
            string hashedPassword = CaloryLibrary.Helper.CalculateMD5Hash(parameter.Password);
            Login login = repo.GetOne<Login>(l => l.Name == UserName && l.Password == hashedPassword);
            if (login != null)
            {
                DisplayWrongCredentialsError = false;
                Global.CurrentUser = UserName;
                MainWindow mainwindow = new MainWindow();
                Application.Current.MainWindow.Close();
                mainwindow.Show();
            }
            else
            {
                DisplayWrongCredentialsError = true;
            }
            IsBusy = false;
        }

        public void RaiseLoginCommandCanExecuteChanged()
        {
            //Called by the view when the password is changed so the login button can be enabled
            LoginCommand.RaiseCanExecuteChanged();
        }
    }
}
