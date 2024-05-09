using DatingApp.Model.Matchfeed;


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
                int i = r.Next(Int32);
                if (CheckUniqueID( r, match)
                {
                    return r;
                }
            }

        }

        //Checks if the random number generated is already used
        private bool CheckUniqueID(int id, bool match)
        {
            if (match)
            {
                string query = @"
            SELECT match_id
            FROM Match
            WHERE match_id = @id"
            }
            else
            {
                string query = @"
            SELECT like_id
            FROM likes
            WHERE like_id = @id"
            }
            

            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@id", id);


                    return true;
                }
            }



            return false;
        }
    }
    
}