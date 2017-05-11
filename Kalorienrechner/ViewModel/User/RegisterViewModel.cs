using CaloryLibrary.Models;
using CaloryLibrary.Repository;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Kalorienrechner.ViewModel.User
{
    public class RegisterViewModel : BindableBase
    {
        private string _userName;
        private bool _displayWrongCredentialsError;
        private bool _displayUserAlreadyExistsError;
        private bool _displaySuccessfulRegistrationNotification;
        private bool _isBusy;
        private CaloryRepository repo = new CaloryRepository();


        public RegisterViewModel()
        {
            RegisterCommand = new DelegateCommand<Tuple<PasswordBox, PasswordBox>>(ExecuterRegister, CanRegister);
        }

        public DelegateCommand<Tuple<PasswordBox, PasswordBox>> RegisterCommand
        {
            get; private set;
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
                RaiseRegisterCommandCanExecuteChanged();
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

        public bool DisplayUserAlreadyExistsError
        {
            get
            {
                return _displayUserAlreadyExistsError;
            }

            set
            {
                SetProperty(ref _displayUserAlreadyExistsError, value);
            }
        }

        public bool DisplaySuccessfulRegistrationNotification
        {
            get
            {
                return _displaySuccessfulRegistrationNotification;
            }

            set
            {
                SetProperty(ref _displaySuccessfulRegistrationNotification, value);
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


        public void RaiseRegisterCommandCanExecuteChanged()
        {
            //Called by the view when the password is changed so the register button can be enabled
            RegisterCommand.RaiseCanExecuteChanged();
        }

        private async void ExecuterRegister(Tuple<PasswordBox, PasswordBox> passwordTuple)
        {
            if (passwordTuple == null)
            {
                throw new ArgumentNullException();
            }
            IsBusy = true;
            Login newUser = new Login();
            newUser.Name = UserName;
            newUser.Password = CaloryLibrary.Helper.CalculateMD5Hash(passwordTuple.Item1.Password);
            await CreateNewUserAsync(newUser);
            DisplayWrongCredentialsError = false;
            DisplaySuccessfulRegistrationNotification = true;
            IsBusy = false;
        }

        private bool CanRegister(Tuple<PasswordBox, PasswordBox> passwordTuple)
        {
            if (passwordTuple == null)
            {
                throw new ArgumentNullException();
            }
            if (UserName != null && UserName.Count() > 0 && DisplayUserAlreadyExistsError == false && passwordTuple.Item1.Password != null && passwordTuple.Item1.Password.Count() > 0 && passwordTuple.Item2.Password != null && passwordTuple.Item2.Password.Count() > 0)
            {
                if (passwordTuple.Item1.Password == passwordTuple.Item2.Password)
                {
                    DisplaySuccessfulRegistrationNotification = false;
                    DisplayWrongCredentialsError = false;
                    return true;
                }
                DisplaySuccessfulRegistrationNotification = false;
                DisplayWrongCredentialsError = true;
            }
            return false;
        }

        private Task CreateNewUserAsync(Login login)
        {
            return Task.Run(() =>
            {
                repo.Create(login);
                repo.Save();
            }
                );
        }

        public async void CheckIfUserExists()
        {
            //Called by the view
            IsBusy = true;
            bool userExists = await repo.GetExistsAsync<Login>(f => f.Name == UserName);
            if (userExists)
            {
                DisplayUserAlreadyExistsError = true;
            }
            else
            {
                DisplayUserAlreadyExistsError = false;
            }
            IsBusy = false;
        }
    }
}
