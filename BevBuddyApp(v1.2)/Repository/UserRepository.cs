using BevBuddyApp_v1._2_.Repository;
using BevBuddyApp_v1._2_.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.Runtime.CompilerServices;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;
using System.Data;
using Microsoft.Identity.Client;


namespace BevBuddyApp_v1._2_.Repository
{
    public class UserRepository : RepositoryBase, IUserRepository, IAccountsRepositoryStoredProcedures
    {
        private readonly AccountsRepositoryStoredProcedures _procedures;

        public UserRepository()
        {
            _procedures = new AccountsRepositoryStoredProcedures();
        }

        public bool AuthenticateUser(NetworkCredential credential)
        {
            bool validUser;
            using var connection = GetConnection();
            try
            {
                connection.Open();

                using var command = new SqlCommand();
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Accounts WHERE username = @Username AND password = @Password";
                    command.Parameters.Add("@Username", SqlDbType.VarChar).Value = credential.UserName;
                    command.Parameters.Add("@Password", SqlDbType.VarChar).Value = credential.Password;
                    validUser = command.ExecuteScalar() != null;
                }
                    
                connection.Close();

                return validUser;
            }
            catch(ArgumentNullException)
            {
                return false;
            }
        }

        public void Add(UserModel userModel)
        {
            _procedures.InsertNewAccount(userModel);
        }

        public void Edit(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public UserModel GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public UserModel GetByUsername(string username)
        {
            UserModel user = null;
            using var connection = GetConnection();
            if (connection == null)
                throw new ArgumentNullException(nameof(connection));

            else
            {
                connection.Open();

                using var command = new SqlCommand();
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Accounts WHERE username = @Username";
                    command.Parameters.Add("@Username", SqlDbType.VarChar).Value = username;

                    using var reader = command.ExecuteReader();
                    {
                        if (reader.Read())
                        {
                            user = new();
                            {
                                user.AccountID = (int)reader[0];                             
                                user.FirstName = (string)reader[1];
                                user.LastName = (string)reader[2];
                                user.Username = (string)reader[3];
                                user.Password = string.Empty;
                            }
                        }
                    }
                }

                connection.Close();

                return user;
            }
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void InsertNewAccount(UserModel userModel)
        {
            _procedures.InsertNewAccount(userModel);
        }
    }
}
