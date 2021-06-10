using System.Linq;
using System.Collections.Generic;
using MinimalApis.Data;

namespace MinimalApis.Repositories
{
    public class UserRepository : IUserRepository
    {
        private List<User> _users { get; set; }
        private long _sequence { get; set; }

        public UserRepository()
        {
            _users = new List<User>();
            _sequence = 0;
        }

        public User Add(string name, string surname, long document)
        {
            if (_users.Any(x => x.Document == document))
                throw new System.ArgumentException("Já existe um usuário com este número de documento");

            var nextId = ++_sequence;
            _users.Add(new User(nextId, name, surname, document));

            return _users.First(x => x.Id == nextId);
        }

        public void Delete(long id)
        {
            if (!_users.Any(x => x.Id == id))
                throw new System.ArgumentException("Usuário não encontrado");

            _users.Remove(_users.Single(x => x.Id == id));
        }

        public List<User> GetAll()
        {
            return _users;
        }

        public User GetById(long id)
        {
            return _users.FirstOrDefault(x => x.Id == id);
        }
    }
}