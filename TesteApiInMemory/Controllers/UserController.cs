using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TesteApiInMemory.Model;
using TesteApiInMemory.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TesteApiInMemory.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {

        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Json(_userRepository.GetAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Json(_userRepository.GetSingle(id));
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]UserModel userModel)
        {
            if (userModel == null)
                return BadRequest();
            return Json(_userRepository.Add(userModel));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]UserModel userModel)
        {
            if (userModel == null)
                return BadRequest();

            return Json(_userRepository.Update(id, userModel));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Json(_userRepository.Delete(id));
        }
    }
}
