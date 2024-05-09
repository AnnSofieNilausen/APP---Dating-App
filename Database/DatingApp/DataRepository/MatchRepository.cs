using DatingApp.Model;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using DatingApp.Model.P;

namespace DatingApp.DataRepository.matches
{
    public class MatchRepository: Repository
    {
        //Get match profiles from List of IDs
        public List<Profile> GetMatchProfiles(int userId)
        {
            List<int> ID = GetMatchIds(userId);
            List<Profile> matches = new List<Profile>();
            for (int i = 0; i < ID.Count; i++)
            {
                matches.Add(GetSafeProfileById(ID[i], true));
            }

           return matches;
        }

        /// <summary>
        /// Retrieves a list of mutual Matches for a specified user by querying the Matches table.
        /// This method finds users that have mutually liked each other.
        /// </summary>
        /// <param name="userId">The user ID to retrieve Matches for.</param>
        /// <returns>A list of user IDs that are mutual Matches.</returns>
        public List<int> GetMatchIds(int userId)
        {
            // SQL query to find mutual Likes.
            // It selects other users who appear as Matches for the given user and where the given user is also a match for them.
            string query = "SELECT * FROM match WHERE (pid_1 = @UserId) OR (pid_2 = @UserId)";

            // Parameters are used to safely inject the user's ID into the SQL query, preventing SQL injection.
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@UserId", userId}
            };

            // Initialize a list to hold the IDs of matching users.
            List<int> matches = new List<int>();

            // Execute the query and iterate over each data record returned.
            foreach (IDataRecord record in GetDataDyn(query, parameters))
            {
                if (Convert.ToInt32(record["pid_1"]) == userId)
                {
                    matches.Add((int)record["pid_2"]);
                }
                else
                {
                    matches.Add((int)record["pid_1"]);
                }
            }

            // Return the list of Matches in ID format.
            return matches;
        }

        /// <summary>
        /// Deletes a match between the specified user and another user from the Matches table.
        /// </summary>
        /// <param name="userId">The user ID of the first user.</param>
        /// <param name="matchUserId">The user ID of the match to be deleted.</param>
        /// <returns>True if the operation was successful, indicating one or more rows were affected, false otherwise.</returns>
        public bool DeleteMatch(int userId, int matchUserId)
        {
            // SQL command to delete a match entry. This deletes rows where either the user or the match is specified in either column,
            // ensuring that all references to this match are removed.
            string query = "DELETE FROM match WHERE (pid_1 = @UserId AND pid_2 = @MatchUserId) OR (pid_1 = @MatchUserId AND pid_2 = @UserId)";

            // Parameters are used to safely inject the user IDs into the SQL command.
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@UserId", userId},
                {"@MatchUserId", matchUserId}
            };

            // Execute the delete command and get the number of rows affected.
            int affectedRows = ExecuteNonQuery(query, parameters);

            // Return true if at least one row was affected, indicating a successful delete.
            return affectedRows > 0;
        }
    }
}
