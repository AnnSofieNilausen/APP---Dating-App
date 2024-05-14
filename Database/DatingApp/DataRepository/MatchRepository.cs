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



        //Returns a list of Ids with which the given id is matched in the database
        public List<int> GetMatchIds(int userId)
        {

            string query = "SELECT * FROM match WHERE (pid_1 = @UserId) OR (pid_2 = @UserId)";

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@UserId", userId}
            };

            // Initialize a list to hold the IDs of matching IDs
            List<int> matches = new List<int>();

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

            // Return the list of Matches in List[IDs] format.
            return matches;
        }



        // Deletes a match between the specified user and another user from the Matches table
        // The user ID of the first user
        // The user ID of the match to be deleted
        // Return true if the operation was successful, indicating one or more rows were affected, false otherwise
        public bool DeleteMatch(int userId, int matchUserId)
        {
            string query = "DELETE FROM match WHERE (pid_1 = @UserId AND pid_2 = @MatchUserId) OR (pid_1 = @MatchUserId AND pid_2 = @UserId)";

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
