using DatingApp.DataRepository;
using DatingApp.Model;
using Microsoft.AspNetCore.Mvc;
using DatingApp.Model.Auth;
using DatingApp.Model.P;

namespace DatingApp.Controllers.Auth
{
    public class AuthenticationController : Controller
    {
        private Repository repository { get; }
        private readonly UserAuthentication userAuthentication;

        public AuthenticationController()
        {
            repository = new Repository();
            userAuthentication = new UserAuthentication();
        }


        [HttpGet("username")]

        public ActionResult Get(string username, string password)
        {
            bool access = userAuthentication.AuthenticateUser(username, password);
            if (access == false)
            {
                return BadRequest($"Wrong password or username");
            }

            else if (access == true)
            {
                int profid = userAuthentication.GetUserIdFromLogin(username, password);
                if (profid == 0) { return BadRequest("Wrong password or username"); }

                else {
                    Profile profile = repository.GetProfileById(profid); 
                    return Ok(profile); }
            }

            else
            {
                return BadRequest($"Something Went Wrong");
            }

        }

    }








}