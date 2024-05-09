using DatingApp.DataRepository;
using DatingApp.Model;
using Microsoft.AspNetCore.Mvc;
using DatingApp.Model.Auth;
using DatingApp.Model.P;

namespace DatingApp.Controllers.Auth
{
    [Route("api/[controller]")]
    public class AuthenticationController : Controller
    {
        private Repository Repository { get; }
        private readonly UserAuthentication userAuthentication;

        public AuthenticationController()
        {
            Repository = new Repository();
            userAuthentication = new UserAuthentication();
        }


        [HttpGet()]
        public ActionResult Get(string username, string password)
        {
            bool access = userAuthentication.AuthenticateUser(username, password);
            if (access == false)
            {
                return BadRequest("Wrong Username or Password");
            }

            else if (access == true)
            {
                int profid = userAuthentication.GetUserIdFromLogin(username, password);
                if (profid == 0) { return BadRequest("Wrong password or Username"); }

                else {
                    Profile profile = Repository.GetProfileById(profid); 
                    return Ok(profile); }
            }

            else
            {
                return BadRequest($"Something Went Wrong");
            }

        }

    }








}