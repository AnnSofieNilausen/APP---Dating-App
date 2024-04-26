using System.Reflection.Metadata.Ecma335;
using DatingApp.DataRepository;
using Npgsql;

namespace DatingApp.Model
{
    public class Match_feed : BaseRepository
    {
        //Connecting string for the database
        private string connectionString = "Host=localhost; Port=5432; Database=Dating App; Username=yourUsername; Password=yourPassword;";
        //first thing we should do is to find another profile, make sure the profile is not either liked or matched. 
        //Method to display a profile for the current user
        public int DisplayProfile(int userId)
        {
            int displayedProfileId = 0;

            //loop until a suitable profile is found
            while (true)
            {
                //Get a random profile ID from the repositary
                displayedProfileId = GetRandomProfileId();

                //Check if the profile is not liked by the current user
                if (!IsLike(userId, displayedProfileId))
                {
                    break; //Exit the loop if the profile is not liked
                }
            }

            return displayedProfileId;
        }

        // Method to retrieve a random profile ID from the repositary
        private int GetRandomProfileId()
        {
            //Implement logic retrieve a random profile ID
            return 0; //Placeholder, replace with actual logic
        }

        //Method to check whether the current user has already liked the displayed profile
        public bool IsProfileLiked(int userId, int profileId)
        {
            bool isLiked = false;

            //SQL query to chedck if the current user has liked the displayed profile
            string query = @"
            SELECT COUNT(*)
            FROM Likes
            WHERE UserId = @UserId AND LikedProfileId = @ProfileId
        ";

            try
            {
                //Establish connection to the PostgreSQL database
                using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
                {

                    using ((NpgsqlCommand command = new NpgsqlCommand(query, connection))
                   {
                        // Add parameters to the command to prevent SQL injection
                        command.Parameters.AddWithValue("@UserId", userId);
                        command.Parameters.AddWithValue("@ProfileId", profileId);

                        // Open the database connection
                        connection.Open();

                        //Execute the query and get the count of rows
                        int count = Convert.ToInt32(command.ExecuteScalar());

                        //checked if the count is greater than 0 to determine if the user has liked the profile 
                        isLiked = count > 0;
                    }

                }
            }
            catch (Exception ex)
            {
                //Handle exception, such as database connection errors
                Console.WriteLine($"Error checking if profile is liked: {ex.Message}");
            }

            return isLiked;
        }




        public bool IsMatch(int userId)
        {
            try
            {
                //SQL query to check if a match exists
                string query = @"
                    SELECT COUNT(*)
                    FROM Likes AS L1
                    JOIN Likes AS L2 ON L1.UserId = L2.LikedProfileId AND L1.LikedProfileId = L2.UserId
                    WHERE L1.UserId = @UserId
                ";

                using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
                {
                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        //Add parameters to the command to prevent SQL injection
                        command.Parameters.AddWithValue("@UserId", userId);

                        connection.Open();
                        int count = Convert.ToInt32(command.ExecuteScalar());

                        //if the count is greater than 0, a match exists

                        return count > 0;
                    }
                }
             catch (Exception ex)
            {
                //Handle exceptions, such as database connection errors
                Console.WriteLine($"Error checking for match: {ex.Message}");
                return false;
            }
        }
        //pull foreign ID from liked persons liked and check if like is mutual
        //if true create match and push it through repository
        //delete like on both IDs in Repository
        //if false return false

        public bool IsLike(int userId, int profileId)
        {
            //Check if the like is a match
            bool isMatch = IsMatch(userId);

            //If it's not a match, add the like to the like list
            if (!isMatch)
            {
                IsProfileLiked(userId, profileId);
            }

            //Return the result based on wheter it's a match
            return isMatch;                     
        }



        //check if like is match call IsMatch function
        //if return false add like to like list through repository
        //return false
        //if true return true
    }

    //testing 
}
