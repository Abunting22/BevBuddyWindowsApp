using BevBuddyApp_v1._2_;
using BevBuddyApp_v1._2_.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Configuration;
using System.Diagnostics.Eventing.Reader;
using System.Linq.Expressions;
using System.Net;

namespace BevBuddyApp_v1._2_.Repository
{
    public abstract class RepositoryBase
    {
        private string _connectionString;

        public RepositoryBase()
        {
            ConnectionString();
        }

        private void ConnectionString()
        {
            var connectionString = "Data Source=DESKTOP-4OBEQSQ;Initial Catalog=BevBuddyApp(v1.0);Integrated Security=True;Encrypt=False"; //Temporary - Need better long-term solution
            _connectionString = connectionString;
        }

        public SqlConnection GetConnection()
        {
            try
            {
                return new SqlConnection(_connectionString);
            }
            catch
            {
                throw new ArgumentNullException();
            }
        }
    }
}
