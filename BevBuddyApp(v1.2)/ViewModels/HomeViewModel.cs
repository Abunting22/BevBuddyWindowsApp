using BevBuddyApp_v1._2_.Models;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BevBuddyApp_v1._2_.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private UserAccountModel _currentUserAccount;
        private ViewModelBase _currentChildView;

        public UserAccountModel CurrentUserAccount { get { return _currentUserAccount; } set { _currentUserAccount = value; OnPropertyChanged(nameof(CurrentUserAccount)); } }
        public ViewModelBase CurrentChildView { get => _currentChildView; set { _currentChildView = value; OnPropertyChanged(nameof(CurrentChildView)); } }

        public ICommand ShowBetViewCommand { get; }

        public HomeViewModel()
        {
            ShowBetViewCommand = new ViewModelCommand(ExecuteShowBetViewCommand);
        }

        private void ExecuteShowBetViewCommand(object obj)
        {
            CurrentChildView = new BetViewModel();
        }
    }
}
