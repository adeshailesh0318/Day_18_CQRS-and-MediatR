using Day18_CQRS_MediatR_API.Features.Users.Commands.CreateUser;
using Day18_CQRS_MediatR_API.Features.Users.Commands.DeleteUser;
using Day18_CQRS_MediatR_API.Features.Users.Commands.UpdateUser;
using Day18_CQRS_MediatR_API.Features.Users.Queries.GetAllUsers;
using Day18_CQRS_MediatR_API.Features.Users.Queries.GetUserById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Day18_CQRS_MediatR_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/users
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _mediator.Send(
                new GetAllUsersQuery());

            return Ok(users);
        }

        // GET: api/users/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _mediator.Send(
                new GetUserByIdQuery(id));

            if (user == null)
            {
                return NotFound("User not found.");
            }

            return Ok(user);
        }

        // POST: api/users
        [HttpPost]
        public async Task<IActionResult> CreateUser(
            CreateUserCommand command)
        {
            var userId = await _mediator.Send(command);

            return Ok(new
            {
                Message = "User created successfully.",
                UserId = userId
            });
        }

        // PUT: api/users/1
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(
            int id,
            UpdateUserCommand command)
        {
            command.Id = id;

            var result = await _mediator.Send(command);

            if (!result)
            {
                return NotFound("User not found.");
            }

            return Ok("User updated successfully.");
        }

        // DELETE: api/users/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _mediator.Send(
                new DeleteUserCommand(id));

            if (!result)
            {
                return NotFound("User not found.");
            }

            return Ok("User deleted successfully.");
        }
    }
}