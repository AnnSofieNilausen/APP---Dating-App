using DatingApp.DataRepository;
using DatingApp.Model.P;
using DatingApp.DataRepository.BaseRepo;
using System;
using DatingApp.Model.IDcreator;
using Microsoft.AspNetCore.Http.HttpResults;

namespace DatingApp.Model.Matchfeed
{
    public class Match_feed : BaseRepository
    {

        public BaseRepository baserepo = new BaseRepository();
        readonly Repository repo = new Repository();
        IDCreator idcreator = new IDCreator();
        
        // Method to retrieve a random profile ID from the repository
        public Profile GetRandomProfile(int userid)
        {
            var rand = new Random();
            string query = "SELECT * FROM profile";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            int count = baserepo.GetDataDyn(query, parameters).Count();
            
            int randid;
            
            while(true)
            {
                randid = rand.Next(count);
                if (randid == userid)
                {
                    continue;
                }
                else
                {
                    break;
                }
                
            }
            Profile Matchfeed_profile = repo.GetSafeProfileById(randid, false);
            return Matchfeed_profile;
            
        }


        
        
        //Method to check whether the current user has already been liked by the displayed profile
        public bool CheckIsLiked(int liker, int liked)
        {
            bool isLiked = false;

            //pid_1 = Liker, pid_2 = Liked
            string query = @"
            SELECT *
            FROM likes
            WHERE pid_1 = @UserId AND pid_2 = @ProfileId
        ";

            try
            {
                Dictionary<string, object> parameter = new Dictionary<string, object>();
                {
                    parameter.Add(@"UserId", liker);
                    parameter.Add(@"ProfileId", liked);
                }

                isLiked = baserepo.GetDataDyn(query, parameter).Count() > 0;

            }
            catch (Exception ex)
            {
                //Handle exception, such as database connection errors
                Console.WriteLine($"Error checking if profile is liked: {ex.Message}");
            }

            return isLiked;
        }

        private bool CheckIsMatch(int liker, int liked)
        {
            try
            {
                //Legacy SQL Statement
                //string query = @"
                //SELECT COUNT(*)
                //FROM likes AS L1
                //JOIN likes AS L2 ON L1.UserId = L2.LikedProfileId AND L1.LikedProfileId = L2.UserId
                //WHERE L1.UserId = @UserId
                //";

                string query = $"SELECT * FROM match WHERE (pid_1 = @userid AND pid_2 = @profileid) OR (pid_1 = @profileid AND pid_2 = userid)";
                Dictionary<string, object> parameter = new Dictionary<string, object>();
                {
                    parameter.Add("@userid", liker);
                    parameter.Add("@profileid", liked);
                }
                //if the count is greater than 0, a match exists
                return baserepo.GetDataDyn(query, parameter).Any();

            }

            catch (Exception ex)
            {
                //Handle exceptions, such as database connection errors
                Console.WriteLine($"Error checking for match: {ex.Message}");
                return false;
            }
        }


        private int CheckIsMutualLike(int liker, int liked)
            {
            
                string query = $"SELECT * FROM likes WHERE (pid_1 = @userid AND pid_2 = @profilepd) OR (pid_1 = @profileid AND pid_2 = @userid)";
                Dictionary<string, object> parameter = new Dictionary<string, object>();
                       {
                           parameter.Add(@"userid", liker);
                           parameter.Add(@"profileid", liked);
                       }
               //if the count is greater than 0, a match exists
              return baserepo.GetDataDyn(query, parameter).Count();

        }
       
        //This goes through the checks and motions when a user likes another
        public object PutLike(int userId, int profileId)
        {   //If it's not a match, add the like to the like list
            if (CheckIsMutualLike(userId, profileId) > 1)
            {
                //Inserts the Match
                string query1 = @"INSERT INTO match (""match_id"",""pid_1"", ""pid_2"") SELECT @matchid, @pid1, @pid2";           

                        Dictionary<string, object> parameter = new Dictionary<string, object>();
                        {
                            parameter.Add(@"pid1", userId);
                            parameter.Add(@"pid2", profileId);
                            parameter.Add(@"matchid", idcreator.GetUniqueIntID(true));
                        }
                        baserepo.GetDataDyn(query1, parameter);     
                    
                
                //Deletes the likes from the like table
                string query = $"DELETE FROM likes WHERE (pid_1 = @pid1 AND pid_2 = @pid2) OR (pid_1 = @pid2 AND pid_2 = @pid1)";

                        Dictionary<string, object> parameter2 = new Dictionary<string, object>();
                        {
                            parameter2.Add("@pid1", userId);
                            parameter2.Add("@pid2", profileId);
                        }
                        baserepo.GetDataDyn(query, parameter2);

                return 1;
            }
            if(CheckIsLiked(userId, profileId)==true)
             {
                //if the like is a duplicate
                //Do Nothing
                return 2;

             }
            if (CheckIsMatch(userId, profileId)==true)
            {
                //Do Nothing if Match already exists
                return 3;


            }if (CheckIsMutualLike(userId,profileId)<=1)
            {
                //Inserts the like
                string query = @"INSERT INTO likes (""like_id"",""pid_1"", ""pid_2"") SELECT @likeid, @pid1, @pid2";

                        Dictionary<string, object> parameter2 = new Dictionary<string, object>();
                        {
                            parameter2.Add(@"pid1", userId);
                            parameter2.Add(@"pid2", profileId);
                            parameter2.Add(@"likeid", idcreator.GetUniqueIntID(false));
                        }
                        baserepo.ExecuteNonQuery(query, parameter2);

                return 4;

            }
            return 5;

        }


        

    }

} 
