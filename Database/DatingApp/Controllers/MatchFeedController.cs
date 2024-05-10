using DatingApp.DataRepository;
using DatingApp.Model;
using Microsoft.AspNetCore.Mvc;
using DatingApp.Model.P;


namespace DatingApp.Controllers.MatchFeed
{
    [Route("api/[controller]")]
    public class MatchfeedController : Controller
    {
        private Repository Repository { get; }

        public MatchfeedController()
        {
            Repository = new Repository();
        }

        //Get a random profile
        [HttpGet]
        public ActionResult Get()
        {

            return Ok();
        }

        //Put a like
        [HttpPut("Like")]
        public ActionResult PutLike(int liker, int liked)
        {
            
            return BadRequest();
        }

        //Put a dislike
        [HttpPut("Dislike")]
        public ActionResult PutDislike(int disliker, int disliked)
        {

            return BadRequest();
        }






    }




}