using Microsoft.AspNetCore.Mvc;
using ApiCRUD.srcs.Domain.DTOs;
using ApiCRUD.srcs.Domain.StatusFactory;
using ApiCRUD.srcs.Api.Result;
using ApiCRUD.srcs.Application.Repository;
using ApiCRUD.srcs.Domain.Intrefaces.IUserRepository;
using ApiCRUD.srcs.Domain.Enums;


namespace MyApp.Namespace
{
    using Result = Result<OutputUserDTO, StatusBase, string>;
    using Status = EnumStatusCode;

    [Route("api/[controller]")]
    [ApiController]
    public class userController : ControllerBase
    {

        private readonly IUserRepository _repository;

        public userController(IUserRepository repository)
            => _repository = repository;

        [HttpGet]
        public async Task<ActionResult<List<Result>>> GetAllUser()
        {
            var users = await _repository.GetUsersAsync();
            
            var ResulUsersList = users.Select(
                user => Result<OutputUserDTO, StatusBase, string>
                .Ok(user, StatusFactory.Ok(), "bla")).ToList();
            return Ok(ResulUsersList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Result>> GetUserById(int id)
        {
            var user = await _repository.GetUserByIdAsync(id);
            if(!user.Success)
                return NotFound(Result.Fail(StatusFactory.NotFound()));
            return Ok(Result.Ok(user,  StatusFactory.Ok(), "bla"));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Result>> DeleteUser(int id)
        {
            bool deleted = await _repository.DeleteUserAsync(id);
            if (!deleted)
                return NotFound(Result.Fail(StatusFactory.NotFound()));
            return Ok(Result.Ok(null, StatusFactory.NoContent(), ""));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Result>> UpdateUser([FromBody] InputUserDTO inputUserDTO, int id)
        {
            OutputUserDTO user = await _repository.UpdateUserAsync(id, inputUserDTO);
            if (!user.Success)
                return NotFound(Result.Fail(StatusFactory.NoContent()));
            return Ok(Result.Ok(user, StatusFactory.Ok(), ""));
        }

        [HttpPost]
        public async  Task<ActionResult<Result>> AddUser([FromBody] InputUserDTO inputUserDTO)
        {
            var user = await _repository.AddUser(inputUserDTO);
            if (!user.Success)
                return NotFound(Result.Fail(StatusFactory.NotAcceptable()));
            return Ok(Result.Ok(user, StatusFactory.Created(), ""));
        }
    }
}
