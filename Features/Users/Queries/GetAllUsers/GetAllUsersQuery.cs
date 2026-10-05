using Day18_CQRS_MediatR_API.Models;
using MediatR;

namespace Day18_CQRS_MediatR_API.Features.Users.Queries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<List<User>>
    {
    }
}