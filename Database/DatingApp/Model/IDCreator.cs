using DatingApp.DataRepository.BaseRepo;
using DatingApp.Model.Matchfeed;
using Npgsql;


//Generates Unique IDs for use when creating a match or Like
namespace DatingApp.Model.IDcreator
{
    public class IDCreator
    {
        readonly BaseRepository baserepo = new();
        Random rand = new Random();

        public int GetUniqueIntID(bool match) 
        {

            while(true)
            {

                int j = rand.Next();          
                if (CheckUniqueID(j, match))
                {
                    return j + 1;
                }
                else
                {
                    return j;
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
            SELECT *
            FROM match
            WHERE match_id = @id";
                }
                else
                {
                    query = @"
            SELECT *
            FROM likes
            WHERE like_id = @id";
                }
           
             
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    {"@id", id}
                };
                //return repo.GetDataDyn(query, parameters).Count();
                return false;
        }
  
        public int GetRandomInt(int max) 
        {
           int r = rand.Next(1, max);

            return r;
        }
    }

    
}