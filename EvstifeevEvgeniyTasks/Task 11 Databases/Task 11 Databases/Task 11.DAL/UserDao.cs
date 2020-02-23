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
    public class UserDao : IUserDaoInterface
    {
        #region UserDao fields
        private static string _connectionString = @"Data Source=DESKTOP-B9I0HE5\SQLEXPRESS01;Initial Catalog=UsersAwards;Integrated Security=True";

        #endregion

        #region UserDao constructor
        /// <summary>
        /// Initializes the dictionary of users.
        /// </summary>
        static UserDao()
        {
        }
        #endregion

        #region UserDao public methods
        /// <summary>
        /// Adds user and returns reference it. If the user already exists
        /// return the reference to the existing user instead.
        /// </summary>
        /// <param name="user"> The user. </param>
        /// <returns> Added User. </returns>
        public User Add(User user)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = $"exec sp_add_user \"{user.Name}\", \"{user.DateOfBirth.Date.ToString("yyyy-MM-dd")}\", \"{user.ImageLink}\"";

                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                   
                    connection.Close();
                    return user;
                }
            }
            return null;
        }

        public void ChangeName(int id, string newName)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = $"exec sp_update_user {id}, \"{newName}\", NULL, NULL";
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void ChangeDateOfBirth(int id, DateTime newDateOfBirth)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = $"exec sp_update_user {id}, NULL, \"{newDateOfBirth.Date.ToString("yyyy-MM-dd")}\", NULL";
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
                command.CommandText = $"exec sp_update_user {id}, NULL, NULL, \"{newImageLink}\"";
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                connection.Close();
            }
        }

        /// <summary>
        /// Removes the user by the id. 
        /// </summary>
        /// <param name="id"> The user's id. </param>
        public void Remove(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = $"exec sp_delete_user {id}";
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                connection.Close();
            }
        }

        /// <summary>
        /// Returns Enumerable of users.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<User> GetAll()
        {
            var users = new List<User>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;

                command.CommandText = "exec sp_getall_users";

                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string link = (reader["imageLink"] as string);
                    var tempUser = new User(reader["name"] as string,
                        DateTime.Parse(reader["dateOfBirth"].ToString()),
                         link == null ? "" : link);
                    tempUser.Id = (int)reader["id"];
                    users.Add(tempUser);
                }

                connection.Close();

                foreach(var user in users)
                {
                    var awards = new List<Award>();

                    command.CommandText = $"exec sp_get_awards_of_user {user.Id}";

                    connection.Open();

                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string link = (reader["image_Link"] as string);
                        var award = new Award(reader["title"] as string,
                            link == null ? "" : link);
                        award.Id = (int)reader["id"];
                        awards.Add(award);
                    }
                    connection.Close();
                    foreach (var award in awards)
                    {
                        user.Awards.Add(award);
                    }
                }
                return users;
            }
        }

        /// <summary>
        /// Returns the user by the id.
        /// </summary>
        /// <param name="id"> The user's id. </param>
        /// <returns></returns>
        public User GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var awards = new List<Award>();
                var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = $"exec sp_get_awards_of_user {id}";

                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string link = (reader["image_Link"] as string);
                    var award = new Award(reader["title"] as string,
                        link == null ? "" : link);
                    award.Id = (int)reader["id"];
                    awards.Add(award);
                    
                }
                connection.Close();

                command.CommandText = $"exec sp_get_by_id_user {id}";

                connection.Open();

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string link = (reader["image_Link"] as string);
                    var user = new User(reader["name"] as string,
                        DateTime.Parse(reader["dateOfBirth"].ToString()),
                       link == null ? "" : link);
                    user.Id = (int)reader["id"];
                    connection.Close();
                    foreach (var award in awards)
                    {
                        user.Awards.Add(award);
                    }
                    return user;
                }
            }
            return null;
        }

        /// <summary>
        /// Adds the awards to the user.
        /// </summary>
        /// <param name="userId"> The user's id. </param>
        /// <param name="awardIds"> 32-bit int array of award ids. </param>
        public void AddAwards(int userId, int[] awardIds)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                foreach (var awardId in awardIds)
                {
                    command.CommandText = $"exec sp_add_award_to_user {userId}, {awardId}";
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// Removes the awards from the user.
        /// </summary>
        /// <param name="userId"> The user's id. </param>
        /// <param name="awardIds"> 32-bit int array of award ids. </param>
        public void RemoveAwards(int userId, int[] awardIds)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                foreach (var awardId in awardIds)
                {
                    command.CommandText = $"exec sp_delete_award_from_user {userId}, {awardId}";
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public string GetImageLink(int id)
        {
            string result = string.Empty;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {

                var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "exec sp_get_by_id_user";

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

    }
}
