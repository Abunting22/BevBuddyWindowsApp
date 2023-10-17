using BevBuddyApp_v1._2_.Models;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using BevBuddyApp_v1._2_.Repository;
using System.Windows.Input;

namespace BevBuddyApp_v1._2_.ViewModels
{
    class BetViewModel : ViewModelBase
    {
        private UserAccountModel _currentUserAccount;
        private ViewModelBase _currentChildView;
        private string _caption;
        private IconChar _icon;

        public UserAccountModel CurrentUserAccount { get { return _currentUserAccount; } set { _currentUserAccount = value; OnPropertyChanged(nameof(CurrentUserAccount)); } }
        public ViewModelBase CurrentChildView { get => _currentChildView; set { _currentChildView = value; OnPropertyChanged(nameof(CurrentChildView)); } }
        public string Caption { get => _caption; set { _caption = value; OnPropertyChanged(nameof(Caption)); } }
        public IconChar Icon { get => _icon; set { _icon = value; OnPropertyChanged(nameof(Icon)); } }

        public ICommand ShowAddBetViewCommand { get; }
        public ICommand ShowUpdateBetViewCommand { get; }
        public ICommand DeleteBetCommand { get; }
        public ICommand ShowAllBetsViewCommand { get; }
        
        public BetViewModel()
        {
            CurrentUserAccount = new UserAccountModel();

            ShowAddBetViewCommand = new ViewModelCommand(ExecuteShowAddBetViewCommand);
            ShowUpdateBetViewCommand = new ViewModelCommand(ExecuteShowUpdataBetViewCommand);
            DeleteBetCommand = new ViewModelCommand(ExecuteDeleteBetCommand);
            ShowAllBetsViewCommand = new ViewModelCommand(ExecuteShowAllBetsViewCommand);

            ExecuteShowAllBetsViewCommand(null);
        }

        private void ExecuteShowAddBetViewCommand(object obj)
        {
            CurrentChildView = new AddBetViewModel();
        }

        private void ExecuteShowUpdataBetViewCommand(object obj)
        {
            CurrentChildView = new UpdateBetViewModel(); 
            Caption = "Update Bet";
            Icon = IconChar.UserGroup;
        }

        private void ExecuteDeleteBetCommand(object obj)
        {

        }

        private void ExecuteShowAllBetsViewCommand(object obj)
        {
            CurrentChildView = new ShowAllBetsViewModel();
            Caption = "View Bets";
            Icon = IconChar.UserGroup;
        }
    }
}
