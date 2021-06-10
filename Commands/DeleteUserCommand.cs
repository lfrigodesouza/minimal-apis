using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MinimalApis.Repositories;

namespace minimal_apis.Commands
{
    public class DeleteUserCommand : IRequest<Unit>
    {
        public DeleteUserCommand(long id)
        {
            Id = id;
        }
        public long Id { get; set; }
    }

    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Unit>
    {
        private readonly IUserRepository _repository;
        public DeleteUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }
        public Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            _repository.Delete(request.Id);
            return Task.FromResult(Unit.Value);
        }
    }
}