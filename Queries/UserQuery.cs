using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MinimalApis.Data;
using MinimalApis.Repositories;

namespace minimal_apis.Queries
{
    public class UserQuery : IRequest<User>
    {
        public UserQuery(long id)
        {
            Id = id;
        }
        public long Id { get; set; }
    }

    public class UserQueryHandler : IRequestHandler<UserQuery, User>
    {
        private readonly IUserRepository _repository;
        public UserQueryHandler(IUserRepository repository)
        {
            _repository = repository;
        }
        public Task<User> Handle(UserQuery request, CancellationToken cancellationToken)
        {
            var user = _repository.GetById(request.Id);
            if (user is null)
                throw new Exception("Usuário não encontrado");

            return Task.FromResult(user);
        }
    }
}