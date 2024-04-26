using System;
using Npgsql;
using DatingApp.DataRepository;
using System.Collections.Generic;

namespace DatingApp.Model
{
    public class UserRegistration : BaseRepository
    {
        public UserRegistration()
        {
        }

        // Method to register a new user
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

            // Prepare the SQL query using parameters to insert user data into the database.
            string query = @"
            INSERT INTO Profile 
            (Fname, Lname, DoB, Email, Phone, Username, Password, Sexual_Orientation, 
            Bio, Searching_For, Interests, Occupation, Pictures, Instagram, Snapchat) 
            VALUES 
            (@Fname, @Lname, @DoB, @Email, @Phone, @Username, @Password, @SexualOrientation, 
            @Bio, @SearchingFor, @Interests, @Occupation, @Pictures, @Instagram, @Snapchat)";

            // Create a dictionary to hold SQL parameters
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@Fname", fname},
                {"@Lname", lname},
                {"@DoB", dob},
                {"@Email", email},
                {"@Phone", phone},
                {"@Username", username},
                {"@Password", password},
                {"@SexualOrientation", sexualOrientation},
                {"@Bio", bio},
                {"@SearchingFor", searchingFor},
                {"@Interests", interests},
                {"@Occupation", occupation},
                {"@Pictures", pictures},
                {"@Instagram", instagram ?? ""},
                {"@Snapchat", snapchat ?? ""}
            };

            // Execute the SQL query to register the user and return the result as true if the operation affected at least one row.
            return ExecuteNonQuery(query, parameters) > 0;
        }
    }
}
