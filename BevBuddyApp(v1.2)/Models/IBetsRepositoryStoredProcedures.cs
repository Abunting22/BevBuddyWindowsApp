using BevBuddyApp_v1._2_.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BevBuddyApp_v1._2_.Models
{
    internal interface IBetsRepositoryStoredProcedures
    {
        BetModel SelectUserWagers(UserAccountModel _currentUserAccount);
        void InsertNewWager(BetModel betModel);
    }
}
