using ApiCRUD.srcs.Domain.Entities;
using ApiCRUD.srcs.Domain.DTOs;

namespace ApiCRUD.srcs.Domain.Intrefaces.IUserServices
{
	public interface IUserRepository
	{
		public Task<OutputUserDTO>	AddUser(OutputUserDTO userDTO);
		
	}
}
