using BevBuddyApp_v1._2_.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace BevBuddyApp_v1._2_.Repository
{
    class RepositoryStoredProcedures : RepositoryBase, IRepositoryStoredProcedures 
    {
        public void InsertNewAccount(UserModel userModel)
        {
            using var connection = GetConnection();
            connection.Open();
            using var command = connection.CreateCommand();
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "InsertNewAccount";

                command.Parameters.AddWithValue("@Username", userModel.Username);
                command.Parameters.AddWithValue("@Password", userModel.Password);
                command.Parameters.AddWithValue("@FirstName", userModel.FirstName);
                command.Parameters.AddWithValue("@LastName", userModel.LastName);

                command.ExecuteNonQuery();
            }
            connection.Close();
        }
    }
}
