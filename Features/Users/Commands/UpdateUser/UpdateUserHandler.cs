using Day18_CQRS_MediatR_API.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Day18_CQRS_MediatR_API.Features.Users.Commands.UpdateUser
{
    public class UpdateUserHandler
        : IRequestHandler<UpdateUserCommand, bool>
    {
        private readonly ApplicationDbContext _context;

        public UpdateUserHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(
            UpdateUserCommand request,
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

            user.Name = request.Name;
            user.Email = request.Email;
            user.Age = request.Age;

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}