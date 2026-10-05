using Day18_CQRS_MediatR_API.Data;
using Day18_CQRS_MediatR_API.Models;
using MediatR;

namespace Day18_CQRS_MediatR_API.Features.Users.Commands.CreateUser
{
    public class CreateUserHandler
        : IRequestHandler<CreateUserCommand, int>
    {
        private readonly ApplicationDbContext _context;

        public CreateUserHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(
            CreateUserCommand request,
            CancellationToken cancellationToken)
        {
            var user = new User
            {
                Name = request.Name,
                Email = request.Email,
                Age = request.Age
            };

            _context.Users.Add(user);

            await _context.SaveChangesAsync(cancellationToken);

            return user.Id;
        }
    }
}