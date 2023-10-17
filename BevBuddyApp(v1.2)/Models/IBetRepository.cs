using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BevBuddyApp_v1._2_.Models
{
    internal interface IBetRepository
    {
        void Add(BetModel betModel);
        void Edit(BetModel betModel);
        void Remove(int id);
        BetModel GetByID(int id);
        BetModel GetByUsername(string username);
        IEnumerable<BetModel> GetAll(UserAccountModel userAccount);
    }
}
