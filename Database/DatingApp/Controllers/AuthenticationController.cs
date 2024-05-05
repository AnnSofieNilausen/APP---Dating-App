using DatingApp.DataRepository;
using DatingApp.Model;
using Microsoft.AspNetCore.Mvc;
using DatingApp.Model.P;
using DatingApp.DataRepository;

namespace DatingApp.Controllers.Auth
{
    public class AuthenticationController : Controller
    {

        public AuthenticationController()
        {
            Repository = new Repository();
            UserAuthentication = new UserAuthentication();
        }


        [HttpGet("username")]
           
                public ActionResult Get(string username, string password)
                {
                    bool access = UserAuthentication.AuthenticateUser(username, password);
                    if (access == false)
                        return BadRequest($"Wrong password or username");
                    else if (access == true)
                    return Repository.GetProfileById();

                    return Ok(profile);
                }
            
    }
    







}