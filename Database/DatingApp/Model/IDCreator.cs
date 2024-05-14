using DatingApp.DataRepository.BaseRepo;
using DatingApp.Model.Matchfeed;
using Npgsql;
using System.Runtime.InteropServices;



//Generates Unique IDs for use when creating a match or Like
namespace DatingApp.Model.IDcreator
{
    public class IDCreator
    { 
        readonly BaseRepository baserepo = new();
        Random rand = new Random();

        public int GetUniqueIntID(bool match, [ Optional ] int rand1) 
        {

            while(true)
            {

                int j = rand.Next();
                //int j = rand1;
                if (!CheckUniqueID(j, match))
                {
                    return j;                   
                }
                

            }
          
        }

        //Checks if the random number generated is already used
        public bool CheckUniqueID(int id, bool match)
        {
                string query;

                if (match)
                {
                    query = @"
            SELECT *
            FROM match
            WHERE match_id = @myid";
                }
                else
                {
                    query = @"
            SELECT *
            FROM likes
            WHERE like_id = @myid";
                }
           
             
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    {"@myid", id}
                };
                return baserepo.GetDataDyn(query, parameters).Count() >0;
      
        }
  
        public int GetRandomInt(int max) 
        {
           int r = rand.Next(1, max);

            return r;
        }
    }

    
}