using Day18_CQRS_MediatR_API.Data;
using Day18_CQRS_MediatR_API.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Day18_CQRS_MediatR_API.Features.Users.Queries.GetUserById
{
    public class GetUserByIdHandler
        : IRequestHandler<GetUserByIdQuery, User?>
    {
        private readonly ApplicationDbContext _context;

        public GetUserByIdHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User?> Handle(
            GetUserByIdQuery request,
            CancellationToken cancellationToken)
        {
            return await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(
                    x => x.Id == request.Id,
                    cancellationToken);
        }
    }
}