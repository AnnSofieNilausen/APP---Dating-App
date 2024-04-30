using DatingApp.DataRepository;
using DatingApp.Model;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.Controllers.Auth
{
    [HttpGet]
    public ActionResult Get()
    {
        return Ok(Repository.GetProfiles());
    }







}