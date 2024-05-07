using DatingApp.DataRepository;
using DatingApp.Model;
using Microsoft.AspNetCore.Mvc;
using DatingApp.DataRepository;
using DatingApp.Model.Auth;

namespace DatingApp.Controllers.Auth
{
    public class AuthenticationController : Controller
    {

        public AuthenticationController()
        {
            Repository repository = new Repository();
            UserAuthentication userAuthentication = new UserAuthentication();
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
                int profid = UserAuthentication.GetUserIdFromLogin(username, password);
                if (profid == 0) { return BadRequest("Wrong password or username"); }

                else { return Repository.GetProfileById(profid); }
            }

            else
            {
                return BadRequest($"Something Went Wrong");
            }

        }

    }








}