using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BevBuddyApp_v1._2_.Repository;
using System.Security;
using System.Security.Principal;
using BevBuddyApp_v1._2_.Models;
using System.Diagnostics.Eventing.Reader;
using BevBuddy_v1._2_.Services;
using BevBuddyApp_v1._2_.Views;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace BevBuddyApp_v1._2_.ViewModels
{
    class CreateUserViewModel : ViewModelBase
    {
        private UserModel _newUserModel;

        public UserModel NewUserModel {get { return _newUserModel;} set { _newUserModel = value; } }

        public ICommand NewUserCommand { get; }

        public CreateUserViewModel()
        {
            NewUserModel = new UserModel();
            NewUserCommand = new ViewModelCommand(ExecuteCreateUserCommand, CanExecuteNewUserCommand);
        }

        public void ExecuteCreateUserCommand(object obj)
        {
            UserRepository userRepository = new();
            userRepository.Add(NewUserModel);
        }

        public bool CanExecuteNewUserCommand(object obj)
        {
            bool validData;
            if (string.IsNullOrWhiteSpace(NewUserModel.Username) ||
                NewUserModel.Username.Length < 4 ||
                NewUserModel.Password == null ||
                NewUserModel.Password.Length < 4 ||
                NewUserModel.FirstName == null ||
                NewUserModel.LastName == null)
                validData = false;
            else
                validData = true;

            return validData;
        }
    }
}

