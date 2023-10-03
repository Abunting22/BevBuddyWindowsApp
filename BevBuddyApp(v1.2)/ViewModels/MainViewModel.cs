using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Azure.Identity;
using BevBuddyApp_v1._2_.Models;
using BevBuddyApp_v1._2_.Repository;
using FontAwesome.Sharp;

namespace BevBuddyApp_v1._2_.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private UserAccountModel _currentUserAccount;
        private ViewModelBase _currentChildView;
        private string _caption;
        private IconChar _icon;

        public UserAccountModel CurrentUserAccount {  get { return _currentUserAccount; } set {  _currentUserAccount = value; OnPropertyChanged(nameof(CurrentUserAccount)); } }

        public ViewModelBase CurrentChildView { get => _currentChildView; set { _currentChildView = value; OnPropertyChanged(nameof(CurrentChildView)); } }
        public string Caption { get => _caption; set { _caption = value; OnPropertyChanged(nameof(Caption)); } }
        public IconChar Icon { get => _icon; set { _icon = value; OnPropertyChanged(nameof(Icon)); } }

        public ICommand ShowHomeViewCommand { get; }
        public ICommand ShowCustomerViewCommand { get; }

        public MainViewModel() 
        {
            CurrentUserAccount = new UserAccountModel();

            ShowHomeViewCommand = new ViewModelCommand(ExecuteShowHomeViewCommand);
            ShowCustomerViewCommand = new ViewModelCommand(ExecuteShowCustomerViewCommand);

            ExecuteShowHomeViewCommand(null);

            LoadCurrentUserData();
        }

        private void ExecuteShowCustomerViewCommand(object obj)
        {
            //CurrentChildView = new CustomerViewModel(); //Needs changed
            Caption = "Customers";
            Icon = IconChar.UserGroup;
        }

        private void ExecuteShowHomeViewCommand(object obj)
        {
            CurrentChildView = new HomeViewModel();
            Caption = "Dashboard";
            Icon = IconChar.UserGroup;
        }

        private void LoadCurrentUserData()
        {            
            UserRepository userRepository = new();
            try
            {
                UserModel user = userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);

                if (user != null)
                {
                    CurrentUserAccount.Username = user.Username;
                    CurrentUserAccount.DisplayName = $"{user.FirstName} {user.LastName}";
                }
            }
            catch(ArgumentNullException)
            {
                CurrentUserAccount.DisplayName = "Invalid user";
            }
        }
    }
}
