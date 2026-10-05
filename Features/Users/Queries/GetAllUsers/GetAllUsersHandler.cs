using Day18_CQRS_MediatR_API.Data;
using Day18_CQRS_MediatR_API.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Day18_CQRS_MediatR_API.Features.Users.Queries.GetAllUsers
{
    public class GetAllUsersHandler
        : IRequestHandler<GetAllUsersQuery, List<User>>
    {
        private readonly ApplicationDbContext _context;

        public GetAllUsersHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> Handle(
            GetAllUsersQuery request,
            CancellationToken cancellationToken)
        {
            return await _context.Users
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
    }
}