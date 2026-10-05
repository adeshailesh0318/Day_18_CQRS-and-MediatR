using Day18_CQRS_MediatR_API.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Day18_CQRS_MediatR_API.Features.Users.Commands.DeleteUser
{
    public class DeleteUserHandler
        : IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly ApplicationDbContext _context;

        public DeleteUserHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(
            DeleteUserCommand request,
            CancellationToken cancellationToken)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(
                    x => x.Id == request.Id,
                    cancellationToken);

            if (user == null)
            {
                return false;
            }

            _context.Users.Remove(user);

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}