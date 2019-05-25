using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TesteApiInMemory.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TesteApiInMemory.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private ApiContext _context;

        public UserController(ApiContext context)
        {
            _context = context;
            if (!_context.Users.Any())
            {

                var address = new Address
                { Country = "Brazil", State = "SP", City = "Guarulhos", Street = "Rua Pedra dourada", Zipcode = "12345" };

                var user = new UserModel
                { Name = "Daniel Saraiva", Email = "danniel.saraiva@gmail.com", Phone = "(11)99999-5555", Address = address };
                _context.Users.Add(user);
                _context.SaveChanges();
            }
        }


        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Json(_context.Users.Include(u => u.Address).ToList());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Json(_context.Users.FirstOrDefault(i => i.UserModelId == id));
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]UserModel userModel)
        {
            if (userModel == null)
                return BadRequest();

            _context.Users.Add(userModel);
            _context.SaveChanges();

            //return CreatedAtRoute("GetUsers", new { id = userModel.UserModelId }, userModel);
            return Ok(userModel.UserModelId);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]UserModel userModel)
        {
            if (userModel == null || userModel.UserModelId != id)
                return BadRequest();

            var user = _context.Users.FirstOrDefault(i => i.UserModelId == id);
            if (user == null)
                return NotFound();

            user.Name = userModel.Name;
            user.Email = userModel.Email;
            user.Address.Street = userModel.Address.Street;

            _context.Users.Update(user);
            _context.SaveChanges();
            return new NoContentResult();

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = _context.Users.FirstOrDefault(i => i.UserModelId == id);
            if (user == null)
                return NotFound();

            _context.Users.Remove(user);
            _context.SaveChanges();

            return new NoContentResult();
        }
    }
}
