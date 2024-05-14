using DatingApp.DataRepository;
using DatingApp.Model;
using Microsoft.AspNetCore.Mvc;
using DatingApp.Model.P;
using Microsoft.AspNetCore.Identity;
using DatingApp.Model.Auth;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DatingApp.Controllers.P
{
    [Route("api/[controller]")]
    public class ProfileController : Controller
    {

        private Repository Repository { get; }
        private readonly UserAuthentication userAuthentication = new();

        public ProfileController()
        {
            Repository = new Repository();
        }

        // GET: api/Profile
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(Repository.GetProfiles());
        }

        // GET api/profile/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            Profile profile = new Profile();
            profile = Repository.GetProfileById(id);
            if (profile == null)
            {
                return NotFound($"Profile with id {id} not found");
            }
            return Ok(profile);
        }


        // PUT api/values/5
        [HttpPut()]
        public ActionResult Put([FromBody] Profile profile)
        {
            
            Profile existingprofile = Repository.GetProfileById(profile.ID);
            if (existingprofile == null)
            {
                return NotFound($"Profile with id {profile.ID} not found");
            }

            bool status = Repository.UpdateProfile(profile);
            if (status)
            {
                return Ok(Repository.GetProfileById(profile.ID));
            }

            return BadRequest("Something went wrong");
        }

        // DELETE api/values/5
        [HttpDelete()]
        public ActionResult Delete(int id, string username, string password)
        {
            bool first = userAuthentication.AuthenticateUser(username, password);
            int second = userAuthentication.GetUserIdFromLogin(username, password);
            if (first && second == id)
            {
                Profile existingProfile = Repository.GetProfileById(id);
                if (existingProfile == null)
                {
                    return NotFound($"Profile with id {id} not found");
                }

                bool status = Repository.DeleteProfile(username);
                if (status)
                {
                    return Ok(true);
                }

                return BadRequest($"Unable to delete profile with id {id}");
            }
            else { return Ok(false); }
        }
            
    }
}


