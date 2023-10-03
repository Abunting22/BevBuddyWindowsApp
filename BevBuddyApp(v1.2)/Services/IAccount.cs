using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BevBuddy_v1._2_.Services
{
    public interface IAccount
    {
        int AccountID { get; }
        string FirstName { get; }
        string LastName { get; }
        string Username {  get; }
        string Password { get; }
    }
}
