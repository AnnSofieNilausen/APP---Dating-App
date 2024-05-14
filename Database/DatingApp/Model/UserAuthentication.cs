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
        //Authenticates user
        public bool AuthenticateUser(string username, string password)
        {
            // SQL query to check if the Username and password combination exists, using parameters.
            string query = "SELECT * FROM login WHERE username = @Username AND password = @password";

            Dictionary<string, object> parameters = new()
            {
            {"@Username", username},
            {"@password", password}
            };

            return GetDataDyn(query, parameters).Count() > 0;

        }

        //Gets the users id when they have logged in and returns it
        public int GetUserIdFromLogin(string username, string password)
        {
            string query1 = "SELECT pid FROM profile,login WHERE profile.Username = @Username AND login.Username = @Username AND login.password = @password";

            Dictionary<string, object> parameters = new()
            {
            {"@Username", username},
            {"@password", password}
            };

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

