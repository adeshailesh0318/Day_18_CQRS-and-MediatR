using Day18_CQRS_MediatR_API.Models;
using MediatR;

namespace Day18_CQRS_MediatR_API.Features.Users.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<User?>
    {
        public int Id { get; set; }

        public GetUserByIdQuery(int id)
        {
            Id = id;
        }
    }
}