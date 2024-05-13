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
        private Repository Repository { get; }
        private Match_feed matchfeed = new();
        public MatchfeedController()
        {
            Repository = new Repository();
            
        }

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
            matchfeed.GetRandomProfile(liker);                               
            return Ok(matchfeed.PutLike(liker, liked) );
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