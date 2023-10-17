using BevBuddyApp_v1._2_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BevBuddyApp_v1._2_.Repository
{
    internal class BetRepository : RepositoryBase, IBetRepository
    {
        private readonly BetsRepositoryStoredProcedures _betRepository;

        public BetRepository()
        {
            _betRepository = new BetsRepositoryStoredProcedures();
        }

        public void Add(BetModel betModel)
        {
            _betRepository.InsertNewWager(betModel);
        }

        public void Edit(BetModel betModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BetModel> GetAll(UserAccountModel userAccount)
        {
            IEnumerable<BetModel> userBets = (IEnumerable<BetModel>)_betRepository.SelectUserWagers(userAccount);
            return userBets;
        }

        public BetModel GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public BetModel GetByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
