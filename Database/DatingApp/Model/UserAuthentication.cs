using System;
using Npgsql;
using System.Data;
using System.Collections.Generic;
using DatingApp.DataRepository;

public class UserAuthentication : BaseRepository
{
    /// <summary>
    /// Authenticates a user by checking if the username and password combination is correct.
    /// </summary>
    /// <param name="username">The username of the user trying to login.</param>
    /// <param name="password">The password of the user trying to login.</param>
    /// <returns>True if authentication is successful, false otherwise.</returns>
    public bool AuthenticateUser(string username, string password)
    {
        // SQL query to check if the username and password combination exists, using parameters.
        string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password";

        // Prepare parameters for the query 
        Dictionary<string, object> parameters = new Dictionary<string, object>
        {
            {"@Username", username},
            {"@Password", password}
        };

        // Call the base class method to execute the query with parameters and get the results.

        var records = GetDataDyn(query, parameters);

    


        // Check if the count of users with the provided username and password is greater than 0.
        foreach (IDataRecord record in records)
        {
            if (record != null && Convert.ToInt32(record[0]) > 0)
                return true;
        }

        // Return false if no user matches the provided credentials.
        return false;
    }
}
