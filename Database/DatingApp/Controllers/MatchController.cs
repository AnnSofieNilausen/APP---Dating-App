using DatingApp.DataRepository;
using DatingApp.Model;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.Controllers.Match
{
    [Route("api/[controller]/[Match]")]
    public class MainController : Controller
    {
        private Repository Repository { get; }

        public MatchfeedController()
        {
            Repository = new Repository();
        }

        // GET: api/Profile
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(Repository.GetProfiles());
        }

        // GET api/Matches/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            Profile profile = Repository.GetProfileById(id);
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
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Profile existingStudent = Repository.GetProfileById(id);
            if (existingStudent == null)
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

