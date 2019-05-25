using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TesteApiInMemory.Model;

namespace TesteApiInMemory.Repositories
{
    public class UserRepository : IUserRepository
    {
        private ApiContext _context;

        public UserRepository(ApiContext context)
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

        public UserModel Add(UserModel toAdd)
        {
            if (toAdd == null)
                return null;

            _context.Users.Add(toAdd);
            Save();
            return toAdd;
        }

        public IEnumerable<UserModel> GetAll()
        {
            return _context.Users.Include(u => u.Address).ToList();
        }

        public UserModel GetSingle(int id)
        {
            return _context.Users.Include(u => u.Address).FirstOrDefault(i => i.UserModelId == id);
        }

        public UserModel Update(int id, UserModel toUpdate)
        {
            if (toUpdate == null)
                return null;

            var user = _context.Users.Include(u => u.Address).FirstOrDefault(i => i.UserModelId == id);
            if (user == null)
                return null;

            user.Name = toUpdate.Name;

            _context.Users.Update(user);
            Save();
            return user;
        }

        public bool Delete(int id)
        {
            var user = _context.Users.FirstOrDefault(i => i.UserModelId == id);
            if (user == null)
                return false;

            _context.Users.Remove(user);
            Save();
            return true;

        }

        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}
