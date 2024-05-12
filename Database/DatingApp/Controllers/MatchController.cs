using DatingApp.DataRepository;
using DatingApp.Model;
using Microsoft.AspNetCore.Mvc;
using DatingApp.DataRepository.matches;
using DatingApp.Model.P;

namespace DatingApp.Controllers.match
{
    [Route("api/[controller]")]
    public class MatchController : Controller
    {
        private Repository Repository { get; }

        public MatchController()
        {
            Repository = new Repository();
        }
        readonly MatchRepository matchrepository = new MatchRepository();

        // GET: api/Profile/5
        [HttpGet()]
        public ActionResult Get()
        {
            return BadRequest("No Profile Found");
        }

        // GET api/Matches/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            List<Profile> profile = new List<Profile>();
            profile = matchrepository.GetMatchProfiles(id);
            if (profile == null)
                return NotFound($"Profile with id {id} not found");

            return Ok(profile);
        }

        //Post
        [HttpPost]
        public ActionResult Post([FromBody] Profile profile)
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

        //Put
        [HttpPut()]
        public ActionResult Put([FromBody] Profile profile)
        {
            return Ok(false);
        }

        // DELETE api/values/5
        [HttpDelete()]
        public ActionResult Delete(int userID, int matcherID)
        {
            Profile existingProfile = Repository.GetProfileById(userID);
            Profile existingForeignProfile = Repository.GetProfileById(matcherID);
            if (existingProfile == null)
            {
                return NotFound($"Profile with id {userID} not found");
           
            }

            bool status = matchrepository.DeleteMatch(userID, matcherID);
            if (status)
            {
                return Ok(true);
            }

            return BadRequest($"Unable to delete match with id {userID}");
        }
    }
}






  
