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


<<<<<<< HEAD
        [HttpPost()]

        public ActionResult Post(string username, string password)
=======
        [HttpGet()]
        public ActionResult Get(string username, string password)
>>>>>>> b93fa2feab9bd3ceb7a2e695bf56b9fda0bda068
        {
            bool access = userAuthentication.AuthenticateUser(username, password);
            if (access == false)
            {
<<<<<<< HEAD
                string i = "bad";
                return Ok(i);
=======
                return BadRequest("Wrong Username or Password");
>>>>>>> b93fa2feab9bd3ceb7a2e695bf56b9fda0bda068
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