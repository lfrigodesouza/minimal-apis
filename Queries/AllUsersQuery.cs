using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MinimalApis.Data;
using MinimalApis.Repositories;

namespace minimal_apis.Queries
{
    public class AllUsersQuery : IRequest<List<User>> { }

    public class AllUsersQueryHandler : IRequestHandler<AllUsersQuery, List<User>>
    {
        private readonly IUserRepository _repository;
        public AllUsersQueryHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public Task<List<User>> Handle(AllUsersQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_repository.GetAll());
        }
    }
}