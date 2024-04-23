using System;
using System.Collections.Generic;
using Npgsql;
using DatingApp.DataRepository;  // Include the namespace for BaseRepository

namespace DatingApp.Model
{
    // Inherits from BaseRepository to use its database connection methods
    public class MatchFinder : BaseRepository
    {
        /// <summary>
        /// Retrieves a list of Profiles that have matched with the given user.
        /// </summary>
        /// <param name="userId">The profile ID of the logged-in user.</param>
        /// <returns>List of Profile objects representing matched users.</returns>
        public List<Profile> GetMatches(int userId)
        {
            List<Profile> matches = new List<Profile>();
            string query = @"
                SELECT p.*
                FROM Profile p
                INNER JOIN Likes l ON p.ID = l.Pid2 OR p.ID = l.Pid
                WHERE (l.Pid = @UserId OR l.Pid2 = @UserId) AND l.Match = TRUE AND p.ID != @UserId";

            using (var conn = new NpgsqlConnection(ConnectionString))
            {
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);

                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Profile matchedProfile = new Profile
                            {
                                ID = Convert.ToInt32(reader["ID"]),
                                FName = reader["Fname"].ToString(),
                                LName = reader["Lname"].ToString(),
                                DOB = Convert.ToDateTime(reader["DoB"]),
                                Email = reader["Email"].ToString(),
                                Phone = reader["Phone"].ToString(),
                                // Other properties as needed
                            };
                            matches.Add(matchedProfile);
                        }
                    }
                }
            }
            return matches;
        }
    }
}
