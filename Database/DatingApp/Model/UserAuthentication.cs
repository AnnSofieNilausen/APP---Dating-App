using System;
using System.Data;
using Npgsql;
using System.Text;
using System.Security.Cryptography;

public class UserAuthentication
{
    // Connection string to connect to the PostgreSQL database.
    private string connectionString = "Host=localhost; Port=5432; Database=Dating App; Username=yourUsername; Password=yourPassword;";

    /// <summary>
    /// Authenticates a user by checking if the username and password combination is correct.
    /// </summary>
    /// <param name="username">The username of the user trying to login.</param>
    /// <param name="password">The password of the user trying to login.</param>
    /// <returns>True if authentication is successful, false otherwise.</returns>
    public bool AuthenticateUser(string username, string password)
    {
        // Hash the provided password to compare with the stored hashed password.
        string hashedPassword = HashPassword(password);

        // SQL command to retrieve the hashed password for the given username.
        string query = "SELECT Password FROM Login WHERE Username = @Username";

        // Create and open a connection to the database using the connection string.
        using (var connection = new NpgsqlConnection(connectionString))
        {
            // Create a command object with the SQL query and the connection.
            using (var command = new NpgsqlCommand(query, connection))
            {
                // Add the username parameter to the command to fill the placeholder in the SQL query.
                command.Parameters.AddWithValue("@Username", username);

                // Open the database connection.
                connection.Open();

                // Execute the command and get the result.
                object result = command.ExecuteScalar();

                // Check if we got a result (i.e., if the user exists).
                if (result != null)
                {
                    // If the user exists, compare the stored hashed password with the provided hashed password.
                    string storedHashedPassword = result.ToString();
                    return hashedPassword == storedHashedPassword;
                }
            }
        }

        // If we reach here, the user does not exist or the password did not match.
        return false;
    }

    /// <summary>
    /// Hashes the password using a simple SHA256 hash algorithm.
    /// </summary>
    /// <param name="password">The password to hash.</param>
    /// <returns>The hashed password as a string.</returns>
    private string HashPassword(string password)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            // Convert the input string to a byte array and compute the hash.
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

            // Loop through each byte of the hashed data and format each one as a hexadecimal string.
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return builder.ToString();
        }
    }
}
