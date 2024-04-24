using System;
using Npgsql;
using DatingApp.DataRepository;

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

            // SQL query to insert user data into the Profile table
            string query = @"
            INSERT INTO Profile 
            (Fname, Lname, DoB, Email, Phone, Username, Password, Sexual_Orientation, 
            Bio, Searching_For, Interests, Occupation, Pictures, Instagram, Snapchat) 
            VALUES 
            ('" + fname + "', '" + lname + "', '" + dob + "', '" + email + "', '" + phone + "', '" + username + "', '" + password + "', '" + sexualOrientation + "', '" + bio + "', '" + searchingFor + "', '" + interests + "', '" + occupation + "', '" + pictures + "', '" + (instagram ?? "") + "', '" + (snapchat ?? "") + "')";

            // Execute the SQL query to register the user and return the result
            return ExecuteNonQuery(query);
        }
    }
}
