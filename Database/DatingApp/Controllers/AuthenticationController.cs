using DatingApp.DataRepository;
using DatingApp.Model;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.Controllers.Auth
{
    [HttpGet("Username")]
    public ActionResult Get()
    {
        public ActionResult Get(int id)
        {
             student = Repository.GetStudentById(id);
            if (student == null)
                return NotFound($"Profile with id {id} not found");

            return Ok(student);
        }
    }







}