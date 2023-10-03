using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BevBuddyApp_v1._2_.Models
{
    internal interface IRepositoryBase
    {
        public string ConnectionString();

        SqlConnection GetConnection(); 
    }
}
