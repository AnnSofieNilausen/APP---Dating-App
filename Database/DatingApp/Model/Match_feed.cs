using System.Reflection.Metadata.Ecma335;
using DatingApp.DataRepository;
using Npgsql;
using DatingApp.Model.P;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DatingApp.Model.Matchfeed
{
    public class Match_feed : BaseRepository
    {
        Repository repo = new Repository();
       
        //first thing we should do is to find another profile, make sure the profile is not either liked or matched. 
        //Method to display a profile for the current user
        // Method to retrieve a random profile ID from the repositary
        private Profile GetRandomProfile()
        {
            string query = "SELECT pid FROM profile ORDER BY RANDOM() LIMIT 1";

            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    connection.Open();
                    int randid = Convert.ToInt32(command.ExecuteScalar());
                    Profile Matchfeed_profile = repo.GetSafeProfileById(randid, false);
                    return Matchfeed_profile;
                }
            }
            
        }

        //Method to check whether the current user has already been liked by the displayed profile
        public bool IsProfileLiked(int liker, int liked)
        {
            bool isLiked = false;

            //SQL query to check if the current user has liked the displayed profile
            //pid_1 = Liker, pid_2 = Liked
            string query = @"
            SELECT COUNT(*)
            FROM likes
            WHERE pid_1 = @UserId AND pid_2 = @ProfileId
        ";

            try
            {
                //Establish connection to the PostgreSQL database
                using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
                {

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                   {
                        // Add parameters to the command to prevent SQL injection
                        command.Parameters.AddWithValue("@UserId", liker);
                        command.Parameters.AddWithValue("@ProfileId", liked);

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
                    FROM likes AS L1
                    JOIN likes AS L2 ON L1.UserId = L2.LikedProfileId AND L1.LikedProfileId = L2.UserId
                    WHERE L1.UserId = @UserId
                ";

                using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
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
            }

            catch (Exception ex)
            {
                //Handle exceptions, such as database connection errors
                Console.WriteLine($"Error checking for match: {ex.Message}");
                return false;
            }
        }
        //pull foreign ID from liked persons liked and check if like is mutual
        //if true create match and push it through Repository
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
        //if return false add like to like list through Repository
        //return false
        //if true return true
    }

    //testing 
}
