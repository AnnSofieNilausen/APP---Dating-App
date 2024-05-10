using DatingApp.DataRepository;
using DatingApp.Model;
using Microsoft.AspNetCore.Mvc;
using DatingApp.Model.P;
using DatingApp.Model.Reg;



namespace DatingApp.Controllers.Registration
{
    [Route("api/[controller]")]
    public class RegistrationController : Controller
    {

        public RegistrationController()
        {
        }


        [HttpPost()]
        public ActionResult Post([FromBody] Profile profile)
        {
            if (profile == null)
            {
                return BadRequest("Profile info not correct");
            }

            bool status = UserRegistration.registeruser(profile);
            if (status)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}