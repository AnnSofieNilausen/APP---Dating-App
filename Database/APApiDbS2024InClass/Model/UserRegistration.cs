using System;
using System.Data;
using Npgsql;
using System.Text;

public class UserRegistration
{
    // Connection string to connect to the PostgreSQL database.
    private string connectionString = "Host=localhost; Port=5432; Database=Dating App; Username=yourUsername; Password=yourPassword;";

    /// <summary>
    /// Registers a new user with their profile information.
    /// </summary>
    /// <param name="fname">First name of the user.</param>
    /// <param name="lname">Last name of the user.</param>
    /// <param name="dob">Date of birth of the user.</param>
    /// <param name="gender">Gender of the user.</param>
    /// <param name="username">Username for the user's account.</param>
    /// <param name="password">Password for the user's account.</param>
    /// <param name="sexualOrientation">Sexual orientation of the user.</param>
    /// <param name="bio">Biography of the user.</param>
    /// <param name="searchingFor">Who or what the user is searching for.</param>
    /// <param name="interests">Interests of the user.</param>
    /// <param name="occupation">Occupation of the user.</param>
    /// <param name="pictures">Profile pictures of the user.</param>
    /// <param name="email">Email of the user.</param>
    /// <returns>True if registration is successful, false otherwise.</returns>
    public bool RegisterUser(
        string fname, string lname, DateTime dob, string gender,
        string username, string password, string sexualOrientation,
        string bio, string searchingFor, string interests,
        string occupation, string pictures, string email)
    {
        // SQL command to insert the new user into the database.
        string query = @"
            INSERT INTO Profile 
            (Fname, Lname, DoB, Gender, Username, Password, Sexual_Orientation, 
            Bio, Searching_For, Interests, Occupation, Pictures, Email) 
            VALUES 
            (@Fname, @Lname, @DoB, @Gender, @Username, @Password, @SexualOrientation, 
            @Bio, @SearchingFor, @Interests, @Occupation, @Pictures, @Email)";

        using (var connection = new NpgsqlConnection(connectionString))
        {
            using (var command = new NpgsqlCommand(query, connection))
            {
                // Add parameters to prevent SQL injection.
                command.Parameters.AddWithValue("@Fname", fname);
                command.Parameters.AddWithValue("@Lname", lname);
                command.Parameters.AddWithValue("@DoB", dob);
                command.Parameters.AddWithValue("@Gender", gender);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password); // Consider hashing this
                command.Parameters.AddWithValue("@SexualOrientation", sexualOrientation);
                command.Parameters.AddWithValue("@Bio", bio);
                command.Parameters.AddWithValue("@SearchingFor", searchingFor);
                command.Parameters.AddWithValue("@Interests", interests);
                command.Parameters.AddWithValue("@Occupation", occupation);
                command.Parameters.AddWithValue("@Pictures", pictures);
                command.Parameters.AddWithValue("@Email", email);

                // Open the database connection and execute the query.
                connection.Open();
                int result = command.ExecuteNonQuery();

                // If one record was created, the registration was successful.
                return result == 1;
            }
        }
    }




    /// <summary>
    /// Creates a hashed version of a password, which is a way to securely store passwords.
    /// Hashing is a one-way process that takes your input and turns it into a fixed-size string
    /// of characters that looks nothing like the original input.
    /// </summary>
    /// <param name="password">The original password text that needs to be secured.</param>
    /// <returns>A new string that represents the hashed password.</returns>
    private string HashPassword(string password)
    {
        // 'using' is a special C# feature that ensures the resources are freed properly
        // after we're done. Here, it's used for our hashing tool, SHA256.
        using (System.Security.Cryptography.SHA256 sha256 = System.Security.Cryptography.SHA256.Create())
        {
            // The password text is turned into a sequence of bytes using UTF8 encoding.
            // This is necessary because hashing works on bytes, not characters.
            byte[] passwordBytes = System.Text.Encoding.UTF8.GetBytes(password);

            // This command takes the byte sequence and scrambles it using SHA256 rules.
            // The result is another byte sequence that looks completely different from the input.
            byte[] hashBytes = sha256.ComputeHash(passwordBytes);

            // We need to turn the scrambled bytes into a string. StringBuilder is a helper
            // that creates strings efficiently.
            StringBuilder builder = new StringBuilder();

            // We go through each byte in our scrambled byte sequence.
            for (int i = 0; i < hashBytes.Length; i++)
            {
                // Each byte is turned into a two-character string.
                // This string is made of hexadecimal characters which are numbers or letters from A-F.
                // 'x2' means we want the hexadecimal string to be two characters long.
                // For example, a byte could be turned into "0a" or "b3".
                builder.Append(hashBytes[i].ToString("x2"));
            }

            // Finally, the StringBuilder gives us the complete string with all the hexadecimal
            // representations of our bytes. This is the hashed password we can store safely.
            return builder.ToString();
        }
    }
}

