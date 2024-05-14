using DatingApp.DataRepository;
using DatingApp.Model;
using Microsoft.AspNetCore.Mvc;
using DatingApp.Model.P;
using DatingApp.Model.Reg;



namespace DatingApp.Controllers.Registration
{

    //Class to register a new Profile
    [Route("api/[controller]")]
    public class RegistrationController : Controller
    {
        private Userregistration Userregistration;

        //function to insert new profile
        [HttpPost()]
        public ActionResult Post([FromBody] Profile profile, string password)
        {
            if (profile == null)
            {
                return BadRequest("Profile info not correct");
            }

            bool status = Userregistration.registerUser(profile, password);
            if (status)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}