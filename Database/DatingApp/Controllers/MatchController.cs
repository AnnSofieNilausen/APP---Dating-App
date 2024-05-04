using DatingApp.DataRepository;
using DatingApp.Model;
using Microsoft.AspNetCore.Mvc;
using DatingApp.DataRepository.Matches

namespace DatingApp.Controllers.Match
{
    [Route("api/[controller]")]
    public class MatchController : Controller
    {
        private Repository Repository { get; }

        public MatchfeedController()
        {
            Repository = new Repository();
        }

        // GET: api/Profile/5
        [HttpGet()
        public ActionResult Get()
        {
            return BadRequest("No Profile Found");
        }

        // GET api/Matches/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            Profile profile = MatchRepository.GetMatchProfiles(id);
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
            if (profile == null)
            {
                return BadRequest("Profile info not correct");
            }

            Profile existinProfile = Repository.GetProfileById(profile.ID);
            if (existinProfile == null)
            {
                return NotFound($"Profile with id {profile.ID} not found");
            }

            bool status = Repository.UpdateProfile(profile);
            if (status)
            {
                return Ok();
            }

            return BadRequest("Something went wrong");
        }

        // DELETE api/values/5
        [HttpDelete("{id}, {id2}")]
        public ActionResult Delete(int userID, int matcherID)
        {
            Profile existingProfile = Repository.GetProfileById(userID);
            Profile existingForeignProfile = Repository.GetProfileById(matcherID);
            if (existingProfile == null)
            {
                return NotFound($"Profile with id {userID} not found");
            }else if (existingForeignProfile == matcherID)
            {
                return NotFound($"Profile with id {matcherID} not found");
            }

            bool status = MatchRepository.DeleteMatch(userID, matcherID);
            if (status)
            {
                return NoContent();
            }

            return BadRequest($"Unable to delete Match with id {id}");
        }
    }
}

//Delete
[HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Profile existingprofile = Repository.GetProfileById(id);
            if (existingprofile == null)
            {
                return NotFound($"Profile with id {id} not found");
            }

            bool status = Repository.DeleteProfile(id);
            if (status)
            {
                return NoContent();
            }

            return BadRequest($"Unable to delete profile with id {id}");
        }




    }


}

