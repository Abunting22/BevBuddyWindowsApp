﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BevBuddyApp_v1._2_.Models
{
    interface IAccountsRepositoryStoredProcedures
    {
        void InsertNewAccount(UserModel userModel);
    }
}
