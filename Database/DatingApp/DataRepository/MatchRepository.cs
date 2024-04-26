using System.Collections.Generic;
using System;
using DatingApp.DataRepository;

namespace DatingApp.Model
{
    // Inherits from BaseRepository which contains methods to interact with the database
    public class MatchFinder : BaseRepository
    {
        /// <summary>
        /// Retrieves all profiles that have matched with the specified user based on mutual likes.
        /// </summary>
        /// <param name="userId">The user ID for whom matches are being retrieved.</param>
        /// <returns>A list of Profile objects representing all matched users.</returns>
        public List<Profile> GetMatches(int userId)
        {
            // List to store matched profiles
            List<Profile> matches = new List<Profile>();

            // Unsafe SQL query with direct user input concatenation
            string query = $@"
                SELECT p.*
                FROM Profile p
                INNER JOIN Likes l ON p.ID = l.Pid2 OR p.ID = l.Pid
                WHERE (l.Pid = {userId} OR l.Pid2 = {userId}) AND l.Match = TRUE AND p.ID != {userId}";

            // Use GetData to fetch data and construct Profile objects for each match
            foreach (var record in GetData(query))  // Assuming GetData is adapted to not use parameters
            {
                matches.Add(new Profile
                {
                    ID = Convert.ToInt32(record["ID"]),
                    FName = record["Fname"].ToString(),
                    LName = record["Lname"].ToString(),
                    DOB = Convert.ToDateTime(record["DoB"]),
                    Email = record["Email"].ToString(),
                    Phone = record["Phone"].ToString(),
                    // Additional properties can be added as needed
                });
            }

            return matches;
        }


        // Method to delete a match between two users
        public bool DeleteMatch(int userId, int matchId)
        {
            // SQL command to delete a match from the Likes table where both user IDs match the given IDs
            string sql = "DELETE FROM Likes WHERE (Pid = @UserId AND Pid2 = @MatchId) OR (Pid = @MatchId AND Pid2 = @UserId) AND Match = TRUE";

            // Call the ExecuteNonQuery method from the BaseRepository class
            int rowsAffected = ExecuteNonQuery(sql);

            // Return true if at least one row was affected, indicating success
            return rowsAffected > 0;
        }
    }
}
