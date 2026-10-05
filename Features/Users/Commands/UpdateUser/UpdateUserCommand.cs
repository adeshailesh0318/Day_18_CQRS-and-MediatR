using MediatR;

namespace Day18_CQRS_MediatR_API.Features.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public int Age { get; set; }
    }
}