using DatingApp.DataRepository;
using DatingApp.Model;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.Controllers.Auth
{
    public class AuthenticationController : Controller
    {

        private Repository Repository { get; }

        public AuthenticationController()
        {
            Repository = new Repository();
        }


        [HttpGet("Username")]
            public ActionResult Get()
            {
                public ActionResult Get(int id)
                {
                    student = Repository.GetStudentById(id);
                    if (student == null)
                        return NotFound($"Profile with id {id} not found");

                    return Ok(student);
                }
            }
    }
    







}