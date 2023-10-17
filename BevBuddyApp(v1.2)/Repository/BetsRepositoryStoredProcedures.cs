using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Azure.Identity;
using BevBuddyApp_v1._2_.Models;
using Microsoft.Data.SqlClient;

namespace BevBuddyApp_v1._2_.Repository
{
    class BetsRepositoryStoredProcedures : RepositoryBase, IBetsRepositoryStoredProcedures
    {
        public BetModel SelectUserWagers(UserAccountModel _currentUserAccount)
        {
            BetModel betModel = null;

            using var connection = GetConnection();
            connection.Open();
            using var command = connection.CreateCommand();
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "SelectUserWagers";

                command.Parameters.Add(new SqlParameter("@Username", _currentUserAccount.Username));

                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    betModel = new();
                    {
                        betModel.Bettor = reader.GetString(2);
                        betModel.Wager = reader.GetInt32(3);
                        betModel.BetParameters = reader.GetString(4);
                        betModel.Winner = reader.GetString(5);
                        betModel.WagerDate = (DateTime)reader.GetSqlDateTime(6);
                    };
                }

                command.ExecuteNonQuery();
            }

            connection.Close();

            return betModel;
        }

        public void InsertNewWager(BetModel betModel)
        {
            using var connection = GetConnection();
            connection.Open();
            using var command = connection.CreateCommand();
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "InsertNewWager";

                command.Parameters.AddWithValue("@BettorName", betModel.Bettor);
                command.Parameters.AddWithValue("@Wager", betModel.Wager);
                command.Parameters.AddWithValue("@BetParameter", betModel.BetParameters);
                command.Parameters.AddWithValue("@Winner", betModel.Winner);
                command.Parameters.AddWithValue("@WagerDate", betModel.WagerDate);

                command.ExecuteNonQuery();
            }
            connection.Close();
        }
    }
}
