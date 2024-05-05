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
           
           
                public ActionResult Get(int id)
                {
                    Profile profile = Repository.GetProfileById(id);
                    if (profile == null)
                        return NotFound($"Profile with id {id} not found");

                    return Ok(profile);
                }
            
    }
    







}