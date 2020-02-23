using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Task6.Interfaces;
using Task6.Entities;

namespace Task_11.DAL
{
    public class AwardDao : IAwardDaoInterface
    {
        #region AwardDao fields
        private string _connectionString = @"Data Source=DESKTOP-B9I0HE5\SQLEXPRESS01;Initial Catalog=UsersAwards;Integrated Security=True";

        #endregion

        #region AwardDao constructor
       
        static AwardDao()
        {
        }
        #endregion

        #region AwardDao public methods
        public Award Add(Award award)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = $"exec sp_add_award \"{award.Title}\", \"{award.ImageLink}\"";

                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {

                    connection.Close();
                    return award;
                }
            }
            return null;
        }

        public void Remove(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = $"exec sp_delete_award {id}";
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public IEnumerable<Award> GetAll()
        {
            var awards = new List<Award>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "exec sp_getall_awards";

                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string link = reader["imageLink"] as string;
                    var award = new Award(reader["title"] as string,
                        link == null ? "" : link);
                    award.Id = (int)reader["id"];
                    awards.Add(award);
                }

                connection.Close();

                return awards;
            }
        }

        public Award GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = $"exec sp_get_by_id_award {id}";

                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string link = reader["imageLink"] as string;
                    var award = new Award(reader["title"] as string,
                        link == null ? "" : link);
                    award.Id = (int)reader["id"];
                    connection.Close();
                    return award;
                }
            }
            return null;
        }

        public void AddUsers(int awardId, int[] userIds)
        {

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                foreach (var userId in userIds)
                {
                    command.CommandText = $"exec sp_add_award_to_user {userId}, {awardId}";
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public void RemoveUsers(int awardId, int[] userIds)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                foreach (var userId in userIds)
                {
                    command.CommandText = $"exec sp_delete_award_from_user {userId}, {awardId}";
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public void ChangeTitle(int id, string newTitle)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = $"exec sp_update_award {id}, \"{newTitle}\", NULL";
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void ChangeImageLink(int id, string newImageLink)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = $"exec sp_update_award {id}, NULL, \"{newImageLink}\"";
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public string GetImageLink(int id)
        {
            string result = string.Empty;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {

                var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "exec sp_get_by_id_award";

                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    result = reader["imageLink"] as string;
                    if (result == null) result = "";
                    connection.Close();
                }
            }
            return result;
        }

        #endregion

        internal static void RemoveInternal(int userId)
        {
            throw new NotImplementedException();
        }

        #region AwardDao private methods
        private void ExportListToFile()
        {

        }
        #endregion
    }
}
