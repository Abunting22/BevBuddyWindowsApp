using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BevBuddy_v1._2_.Services
{
    interface IBet
    {
        int AccountID { get; }
        int WagerID { get; }
        string Bettor { get; }
        int Wager { get; }
        string BetParameters { get; }
        string Winner { get; }
        DateTime WagerDate { get; }
    }
}
