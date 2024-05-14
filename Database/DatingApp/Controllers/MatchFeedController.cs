using DatingApp.DataRepository;
using DatingApp.Model;
using Microsoft.AspNetCore.Mvc;
using DatingApp.Model.P;
using DatingApp.Model.Matchfeed;

namespace DatingApp.Controllers.MatchFeed
{
    [Route("api/[controller]")]
    public class MatchfeedController : Controller
    {
        private Match_feed matchfeed = new();
        
        /*
        Get a random profile
        Needs id of the profile who is logged in
        Returns Profile
        */
        [HttpGet("GetProfile")]
        public ActionResult Get(int id)
        {
            
            return Ok(matchfeed.GetRandomProfile(id));
        }

        /*
        Put a like
        Requires both the id of the liker and liked
        Returns Profile
        */
        [HttpPut("Like")]
        public ActionResult PutLike(int liker, int liked)
        {
            matchfeed.PutLike(liker, liked);                                           
            return Ok(matchfeed.GetRandomProfile(liker));
        }


        /*
        Put a dislike
        Requires both the id of the disliker and the disliked
        Returns Profile
        */
        [HttpPut("Dislike")]
        public ActionResult PutDislike(int disliker, int disliked)
        {
            
            return Ok(matchfeed.GetRandomProfile(disliker));
        }
    }
}