using DatingApp.DataRepository.BaseRepo;
using DatingApp.Model.Matchfeed;
using Npgsql;


//Generates Unique IDs for use when creating a match or Like
namespace DatingApp.Model.IDcreator
{
    public class IDCreator : Match_feed
    {
        BaseRepository baserepo = new();
        Random r = new Random();
        public int GetUniqueIntID(bool match) 
        {
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
           
             
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    {"@id", id}
                };
                return baserepo.ExecuteNonQuery(query, parameters) > 0;
        }

        public int GetRandomInt(int max) 
        {
            int rand =r.Next(max);

            return rand;

        }
    }

    
}