using BevBuddy_v1._2_.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BevBuddyApp_v1._2_.Models
{
    class BetModel : IBet
    {
        public int AccountID { get; set; }
        public int WagerID { get; set; }
        public string Bettor { get; set; }
        public int Wager { get; set; }
        public string BetParameters { get; set; }
        public string Winner { get; set; }
        public DateTime WagerDate { get; set; }
    }
}
