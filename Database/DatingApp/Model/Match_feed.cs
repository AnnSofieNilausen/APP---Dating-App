using System.Reflection.Metadata.Ecma335;
using DatingApp.DataRepository;
using Npgsql;
using DatingApp.Model.P;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DatingApp.Model.Matchfeed
{
    public class Match_feed : BaseRepository
    {
        readonly Repository repo = new Repository();

        // Method to retrieve a random profile ID from the repository
        private Profile GetRandomProfile(int userid)
        {
            string query = "SELECT pid FROM profile ORDER BY RANDOM() LIMIT 1";

            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    int randid;
                    while (true)
                    {
                        connection.Open();
                        randid = Convert.ToInt32(command.ExecuteScalar());
                        if (randid != userid)
                        {
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }

                    Profile Matchfeed_profile = repo.GetSafeProfileById(randid, false);
                    return Matchfeed_profile;
                }
            }

        }

        //Method to check whether the current user has already been liked by the displayed profile
        public bool IsProfileLiked(int liker, int liked)
        {
            bool isLiked = false;

            //pid_1 = Liker, pid_2 = Liked
            string query = @"
            SELECT COUNT(*)
            FROM likes
            WHERE pid_1 = @UserId AND pid_2 = @ProfileId
        ";

            try
            {

                using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
                {

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", liker);
                        command.Parameters.AddWithValue("@ProfileId", liked);
                        connection.Open();

                        int count = Convert.ToInt32(command.ExecuteScalar());

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




        private bool IsMatch(int liker, int liked)
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
                        command.Parameters.AddWithValue("@UserId", liker);

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

        public bool PutLike(int userId, int profileId)
        {
            //Check if the like is a match
            bool isMatch = IsMatch(userId, profileId);

            //If it's not a match, add the like to the like list
            if (!isMatch)
            {
                IsProfileLiked(userId, profileId);
            }

            //Return the result based on wheter it's a match
            //If return = false, its not a match but like has been added
            //If return = true, its a match, and the database has been updated
            return isMatch;
        }




    }

} 
