using System;
using System.Collections.Generic;
using TesteApiInMemory.Model;

namespace TesteApiInMemory.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<UserModel> GetAll();
        UserModel GetSingle(int id);
        UserModel Add(UserModel toAdd);
        UserModel Update(int id, UserModel toUpdate);
        bool Delete(int id);
        int Save();
    }
}
