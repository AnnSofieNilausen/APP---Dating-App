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

        //Post a like
        [HttpPost("{id}, {id1}")]
        public ActionResult Post(int liker, int liked)
        {
            if (profile == null)
            {
                return BadRequest("Profile info not correct");
            }

            bool status = Repository.InsertProfile(profile);
            if (status)
            {
                return Ok();
            }

            return BadRequest();
        }







    }




}