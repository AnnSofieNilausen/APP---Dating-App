using APApiDbS2024InClass.DataRepository;
using APApiDbS2024InClass.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APApiDbS2024InClass.Controllers
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
        public ActionResult Post([FromBody]Profile student)
        {
            if (student == null)
            {
                return BadRequest("Profile info not correct");
            }

            bool status = Repository.InsertStudent(student);
            if (status)
            {
                return Ok();
            }

            return BadRequest();
        }

        // PUT api/values/5
        [HttpPut()]
        public ActionResult Put([FromBody] Profile student)
        {
            if (student == null)
            {
                return BadRequest("Profile info not correct");
            }

            Profile existinStudent = Repository.GetStudentById(student.ID);
            if (existinStudent == null)
            {
                return NotFound($"Profile with id {student.ID} not found");
            }

            bool status = Repository.UpdateStudent(student);
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
            Profile existingStudent = Repository.GetStudentById(id);
            if (existingStudent == null)
            {
                return NotFound($"Profile with id {id} not found");
            }

            bool status = Repository.DeleteStudent(id);
            if (status)
            {
                return NoContent();
            }

            return BadRequest($"Unable to delete student with id {id}");
        }
    }
}

