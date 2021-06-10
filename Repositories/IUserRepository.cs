using System.Collections.Generic;
using MinimalApis.Data;

namespace MinimalApis.Repositories
{
    public interface IUserRepository
    {
        void Delete(long id);
        User Add(string name, string surname, long document);
        User GetById(long id);
        List<User> GetAll();
    }
}