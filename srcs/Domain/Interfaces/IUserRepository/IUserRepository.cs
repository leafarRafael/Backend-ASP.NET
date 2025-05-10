using ApiCRUD.srcs.Domain.Entities;
using ApiCRUD.srcs.Domain.DTOs;
namespace ApiCRUD.srcs.Domain.Intrefaces.IUserRepository
{
	public interface IUserRepository
	{
		public Task<OutputUserDTO>			GetUserByIdAsync(int id);
		public Task<List<OutputUserDTO>>	GetUsersAsync();
		public Task<OutputUserDTO>			AddUser(InputUserDTO inputUserDTO);
		public Task<OutputUserDTO>			UpdateUserAsync(int id, InputUserDTO inputUserDTO);
		public Task<bool> 					DeleteUserAsync(int id);
		public Task<bool>					ExistsEmail(string email);
		public Task<bool>					ExistsPhone(string phone);
	}
}



