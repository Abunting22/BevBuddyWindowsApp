using BevBuddy_v1._2_.Services;
using BevBuddyApp_v1._2_.Models;
using BevBuddyApp_v1._2_.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BevBuddyApp_v1._2_.Views;

namespace BevBuddyApp_v1._2_.ViewModels
{
    class AddBetViewModel : ViewModelBase
    {
        private BetModel _newBetModel;
        private ViewModelBase _currentChildView;
        private UserAccountModel _currentUserAccount;

        public UserAccountModel CurrentUserAccount { get { return _currentUserAccount; } set { _currentUserAccount = value; OnPropertyChanged(nameof(CurrentUserAccount)); } }
        public BetModel NewBetModel { get {  return _newBetModel; } set { _newBetModel = value; } }
        public ViewModelBase CurrentChildView { get => _currentChildView; set { _currentChildView = value; OnPropertyChanged(nameof(CurrentChildView)); } }

        public ICommand NewBetCommand { get; }

        public AddBetViewModel() 
        {
            CurrentUserAccount = new UserAccountModel();
            NewBetModel = new BetModel();
            NewBetCommand = new ViewModelCommand(ExecuteAddNewBetCommand, CanExecuteAddNewBetCommand);
        }

        private void ExecuteAddNewBetCommand(object obj)
        {
            BetRepository betRepository = new();
            betRepository.Add(NewBetModel);
        }

        private bool CanExecuteAddNewBetCommand(object obj)
        {
            bool validData;
            if (string.IsNullOrWhiteSpace(NewBetModel.Bettor) ||
                NewBetModel.Bettor.Length < 4 ||
                NewBetModel.Wager <= 0 ||
                NewBetModel.BetParameters == null)
                validData = false;
            else
                validData = true;

            return validData;
        }
    }
}
