using System;
using System.Data;
using Npgsql;
using System.Text;
using APApiDbS2024InClass.DataRepository;  // Include the namespace for BaseRepository

namespace APApiDbS2024InClass.Model
{
    // UserRegistration class inherits from BaseRepository to utilize its database methods
    public class UserRegistration : BaseRepository
    {
        // Constructor initializes the UserRegistration instance
        public UserRegistration()
        {
        }

        /// <summary>
        /// Registers a new user with their profile information.
        /// Requires either an Instagram or a Snapchat account, but not both null.
        /// </summary>
        /// <param name="fname">User's first name.</param>
        /// <param name="lname">User's last name.</param>
        /// <param name="dob">User's date of birth.</param>
        /// <param name="email">User's email address.</param>
        /// <param name="phone">User's phone number.</param>
        /// <param name="username">User's chosen username.</param>
        /// <param name="password">User's chosen password.</param>
        /// <param name="sexualOrientation">User's sexual orientation.</param>
        /// <param name="bio">User's biography.</param>
        /// <param name="searchingFor">What the user is searching for.</param>
        /// <param name="interests">User's interests.</param>
        /// <param name="occupation">User's occupation.</param>
        /// <param name="pictures">User's profile pictures.</param>
        /// <param name="instagram">User's Instagram account, optional.</param>
        /// <param name="snapchat">User's Snapchat account, optional.</param>
        /// <returns>True if registration is successful, false otherwise.</returns>

        public bool RegisterUser(
            string fname, string lname, DateTime dob, string email, string phone,
            string username, string password, string sexualOrientation,
            string bio, string searchingFor, string interests,
            string occupation, string pictures, string instagram = null, string snapchat = null)
        {
            // Validation to ensure at least one social media account is provided
            if (string.IsNullOrEmpty(instagram) && string.IsNullOrEmpty(snapchat))
            {
                throw new ArgumentException("At least one social media account (Instagram or Snapchat) must be provided.");
            }

            // Hash the password for security using a private method
            string hashedPassword = HashPassword(password);

            // SQL command to insert the user data into the Profile table
            string query = @"
            INSERT INTO Profile 
            (Fname, Lname, DoB, Email, Phone, Username, Password, Sexual_Orientation, 
            Bio, Searching_For, Interests, Occupation, Pictures, Instagram, Snapchat) 
            VALUES 
            (@Fname, @Lname, @DoB, @Email, @Phone, @Username, @Password, @SexualOrientation, 
            @Bio, @SearchingFor, @Interests, @Occupation, @Pictures, @Instagram, @Snapchat)";

            // Create and open a new connection to the database using the protected ConnectionString from BaseRepository
            using (var conn = new NpgsqlConnection(ConnectionString))
            {
                // Create a command for the SQL query
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    // Add parameters to the command object to prevent SQL injection
                    cmd.Parameters.AddWithValue("@Fname", fname);
                    cmd.Parameters.AddWithValue("@Lname", lname);
                    cmd.Parameters.AddWithValue("@DoB", dob);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Phone", phone);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", hashedPassword);
                    cmd.Parameters.AddWithValue("@SexualOrientation", sexualOrientation);
                    cmd.Parameters.AddWithValue("@Bio", bio);
                    cmd.Parameters.AddWithValue("@SearchingFor", searchingFor);
                    cmd.Parameters.AddWithValue("@Interests", interests);
                    cmd.Parameters.AddWithValue("@Occupation", occupation);
                    cmd.Parameters.AddWithValue("@Pictures", pictures);
                    cmd.Parameters.AddWithValue("@Instagram", instagram ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Snapchat", snapchat ?? (object)DBNull.Value);

                    // Execute the insert command using a method from BaseRepository
                    return InsertData(conn, cmd);
                }
            }
        }

        /// <summary!>
        /// Creates a hashed version of a password to securely store passwords.
        /// Hashing is a one-way process using SHA256.
        /// </summary>
        /// <param name="password">The original password text that needs to be secured.</param>
        /// <returns>A new string that represents the hashed password.</returns>
        private string HashPassword(string password)
        {
            // Create a SHA256 hash algorithm object
            using (System.Security.Cryptography.SHA256 sha256 = System.Security.Cryptography.SHA256.Create())
            {
                // Convert the password string into a byte array
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                // Compute the hash of the byte array
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);
                // Convert hash bytes to hexadecimal format for storage
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    builder.Append(hashBytes[i].ToString("x2"));
                }
                // Return the hexadecimal string
                return builder.ToString();
            }
        }
    }
}
