using BevBuddyApp_v1._2_.Models;
using BevBuddyApp_v1._2_.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BevBuddyApp_v1._2_.ViewModels
{
    class ShowAllBetsViewModel : ViewModelBase
    {
        private readonly BetRepository _betRepository;

        public void ShowAllBetsView(UserAccountModel _currentUserAccount)
        {
            _betRepository.GetAll(_currentUserAccount);
        }
    }
}
