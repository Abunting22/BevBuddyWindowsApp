using BevBuddyApp_v1._2_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BevBuddyApp_v1._2_.Repository;
using System.Threading;
using System.Security.Principal;
using Microsoft.Data.SqlClient;
using System.Threading.Channels;
using BevBuddyApp_v1._2_.Views;
using System.Drawing.Text;
using System.Windows.Forms;

namespace BevBuddyApp_v1._2_.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private string _username;
        private SecureString _password; //Change to hashmaps??
        private string _errorMessage;
        private bool _isViewVisible = true;

        private readonly IUserRepository userRepository;

        public string Username { get => _username; set { _username = value; OnPropertyChanged(nameof(Username)); } }
        public SecureString Password { get => _password; set { _password = value; OnPropertyChanged(nameof(Password)); } }
        public string ErrorMessage { get => _errorMessage; set { _errorMessage = value; OnPropertyChanged(nameof(ErrorMessage)); } }
        public bool IsViewVisible { get => _isViewVisible; set { _isViewVisible = value; OnPropertyChanged(nameof(IsViewVisible)); } }

        public ICommand LoginCommand { get; }
        public ICommand ShowCreateUserViewCommand { get; }
        public ICommand RecoverPasswordCommand { get; }
        public ICommand ShowPasswordCommand { get; }
        public ICommand RememberPasswordCommand { get; }


        public LoginViewModel()
        {
            userRepository = new UserRepository();
            LoginCommand = new ViewModelCommand(ExecuteLoginCommmand, CanExecuteLoginCommand);
            ShowCreateUserViewCommand = new ViewModelCommand(CreateUserViewCommand);
            RecoverPasswordCommand = new ViewModelCommand(p => ExecuteRecoverPasswordCommand("", ""));
        }
        
        private bool CanExecuteLoginCommand(object obj)
        {
            bool validData;
            if (string.IsNullOrWhiteSpace(Username) || 
                Username.Length < 4 || 
                Password == null || 
                Password.Length < 3)
                validData = false;
            else
                validData = true;
            
            return validData;
        }

        private void ExecuteLoginCommmand(object obj)
        {
            var isValidUser = userRepository.AuthenticateUser(new System.Net.NetworkCredential(Username, Password));
            if (isValidUser) 
            {
                Thread.CurrentPrincipal = new GenericPrincipal(
                    new GenericIdentity(Username), null);
                IsViewVisible = false;
            }
            else
            {
                ErrorMessage = "* Invalid username or password.";
            }
        }
        
        private void ExecuteRecoverPasswordCommand(string username, string email)
        {
            throw new NotImplementedException();
        }

        private void CreateUserViewCommand(object obj)
        {
            var createUserView = new CreateUserView();
            createUserView.Show();
        }
    }
}
