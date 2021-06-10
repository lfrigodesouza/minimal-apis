using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MinimalApis.Data;
using MinimalApis.Repositories;

namespace minimal_apis.Commands
{
    public class AddUserCommand : IRequest<User>
    {
        public string Name { get; set; }
        public long Document { get; set; }
        public string SurName { get; set; }

    }

    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, User>
    {
        private readonly IUserRepository _repository;
        public AddUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;

        }
        public Task<User> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var newUser = _repository.Add(request.Name, request.SurName, request.Document);
            return Task.FromResult(newUser);
        }
    }
}