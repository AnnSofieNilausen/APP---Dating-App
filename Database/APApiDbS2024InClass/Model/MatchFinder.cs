using System;
using System.Collections.Generic;
using Npgsql;
using APApiDbS2024InClass.DataRepository;

namespace APApiDbS2024InClass.Model
{
    // This class 'MatchFinder' extends 'BaseRepository' which likely provides database access methods such as the connection string.
    public class MatchFinder : BaseRepository
    {
        /// <summary>
        /// Method to retrieve a list of user profiles that have mutually liked with the specified user, indicating a match.
        /// </summary>
        /// <param name="userId">The unique identifier for the user whose matches are to be retrieved.</param>
        /// <returns>Returns a list containing Profile objects, each representing a user who has matched with the specified user.</returns>
        public List<Profile> GetMatches(int userId)
        {
            // Create an empty list to hold the matching profiles.
            List<Profile> matches = new List<Profile>();

            // SQL query to retrieve profiles that have a mutual like with the specified user. It joins the Profile table with the Likes table on user IDs.
            string query = @"
                SELECT p.*
                FROM Profile p
                INNER JOIN Likes l ON p.ID = l.Pid2 OR p.ID = l.Pid
                WHERE (l.Pid = @UserId OR l.Pid2 = @UserId) AND l.Match = TRUE AND p.ID != @UserId";

            // Open a new database connection using the connection string from BaseRepository.
            using (var conn = new NpgsqlConnection(ConnectionString))
            {
                // Create a new command object to run the SQL query.
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    // Add the userId parameter to the command to prevent SQL injection.
                    cmd.Parameters.AddWithValue("@UserId", userId);

                    // Open the database connection.
                    conn.Open();

                    // Execute the command, which returns a reader object for accessing the fetched data.
                    using (var reader = cmd.ExecuteReader())
                    {
                        // Loop through all records returned by the SQL query.
                        while (reader.Read())
                        {
                            // Create a new Profile object for each matching record and populate its properties from the database fields.
                            Profile matchedProfile = new Profile
                            {
                                ID = Convert.ToInt32(reader["ID"]),
                                FName = reader["Fname"].ToString(),
                                LName = reader["Lname"].ToString(),
                                DOB = Convert.ToDateTime(reader["DoB"]),
                                Email = reader["Email"].ToString(),
                                Phone = reader["Phone"].ToString(),
                                // Populate other properties as needed
                            };

                            // Add the populated Profile object to the list of matches.
                            matches.Add(matchedProfile);
                        }
                    }
                }
            }

            // Return the list of matched profiles.
            return matches;
        }
    }
}
