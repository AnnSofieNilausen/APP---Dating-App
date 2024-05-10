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
        private Userregistration Userregistration;

        [HttpPost()]
        public ActionResult Post([FromBody] Profile profile, string password)
        {
            if (profile == null)
            {
                return BadRequest("Profile info not correct");
            }

            bool status = Userregistration.registeruser(profile, password);
            if (status)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}