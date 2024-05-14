using System;
using Npgsql;
using System.Data;
using System.Collections.Generic;
using DatingApp.DataRepository;
using DatingApp.DataRepository.BaseRepo;
namespace DatingApp.Model.Auth
{
    public class UserAuthentication : BaseRepository
    {
        /// <summary>
        /// Authenticates a user by checking if the Username and password combination is correct.
        /// </summary>
        /// <param name="username">The Username of the user trying to login.</param>
        /// <param name="password">The password of the user trying to login.</param>
        /// <returns>True if authentication is successful, false otherwise.</returns>
        public bool AuthenticateUser(string username, string password)
        {
            // SQL query to check if the Username and password combination exists, using parameters.
            string query = "SELECT * FROM login WHERE username = @Username AND password = @password";

            // Prepare parameters for the query 
            Dictionary<string, object> parameters = new()
            {
            {"@Username", username},
            {"@password", password}
            };


        // Call the base class method to execute the query with parameters and get the results.

            return GetDataDyn(query, parameters).Count() > 0;

        }

        public int GetUserIdFromLogin(string username, string password)
        {
            string query1 = "SELECT pid FROM profile,login WHERE profile.Username = @Username AND login.Username = @Username AND login.password = @password";
            // Prepare parameters for the query 
            Dictionary<string, object> parameters = new()
            {
            {"@Username", username},
            {"@password", password}
            };

            // Call the base class method to execute the query with parameters and get the results.
            var records = GetDataDyn(query1, parameters);
            foreach (IDataRecord record in records)
            {
                if (record != null && Convert.ToInt32(record[0]) > 0)
                {
                    return Convert.ToInt32(record[0]);
                }

                return 0;
                
                
            }
            return 0;

        }
    }

}

