using DatingApp.DataRepository;
using DatingApp.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DatingApp.Controllers
{
    [Route("api/[controller]")]
    public class ProfileController : Controller
    {
        private Repository Repository { get; }

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
        
        // GET api/student/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            Profile student = Repository.GetStudentById(id);
            if (student == null)
                return NotFound($"Profile with id {id} not found");

            return Ok(student);
        }

       
        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody]Profile profile)
        {
            if (profile == null)
            {
                return BadRequest("Profile info not correct");
            }

            bool status = Repository.InsertStudent(profile);
            if (status)
            {
                return Ok();
            }

            return BadRequest();
        }

        // PUT api/values/5
        [HttpPut()]
        public ActionResult Put([FromBody] Profile profile)
        {
            if (profile == null)
            {
                return BadRequest("Profile info not correct");
            }

            Profile existingprofile = Repository.GetProfileById(profile.ID);
            if (existingprofile == null)
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
            Profile existingProfile = Repository.GetProfileById(id);
            if (existingProfile == null)
            {
                return NotFound($"Profile with id {id} not found");
            }

            bool status = Repository.DeleteProfile(id);
            if (status)
            {
                return NoContent();
            }

            return BadRequest($"Unable to delete student with id {id}");
        }
    }
}

