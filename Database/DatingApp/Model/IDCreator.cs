using DatingApp.Model.Matchfeed;
using Npgsql;


//Generates Unique IDs for use when creating a match or Like
namespace DatingApp.Model.IDcreator
{
    public class IDCreator : Match_feed
    {
        public int GetUniqueIntID(bool match) 
        {
            Random r = new Random();
            while (true)
            {
                int i = r.Next();
                if (CheckUniqueID( i, match))
                {
                    return i;
                }
            }

        }

        //Checks if the random number generated is already used
        private bool CheckUniqueID(int id, bool match)
        {
                string query;

                if (match)
                {
                    query = @"
            SELECT COUNT(*)
            FROM Match
            WHERE match_id = @id";
                }
                else
                {
                    query = @"
            SELECT COUNT(*)
            FROM likes
            WHERE like_id = @id";
                }


                using NpgsqlConnection connection = new NpgsqlConnection(ConnectionString);

                using NpgsqlCommand command = new NpgsqlCommand(query, connection);                
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
                connection.Open();
                int result = int.Parse(command.ExecuteScalar().ToString());
                bool unique = (result == 0);
                connection.Close();

                return unique;
        }
    }
    
}