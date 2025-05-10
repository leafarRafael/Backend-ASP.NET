using ApiCRUD.srcs.Domain.Intrefaces.IUserRepository;
using ApiCRUD.srcs.Domain.Entities;
using ApiCRUD.srcs.Domain.DTOs;
using ApiCRUD.srcs.Persistence.DataContext;
using Microsoft.EntityFrameworkCore;


namespace ApiCRUD.srcs.Application.Repository
{
	public class UserRepository : IUserRepository
	{
		private readonly DataContext	_dbContext;
		public UserRepository(DataContext dbContex) => _dbContext = dbContex;
		public async	Task<OutputUserDTO> AddUser(InputUserDTO inputUserDTO)
		{
			OutputUserDTO outputUserDTO = new OutputUserDTO() { Success = false };
			UserEntity userEntity = new UserEntity
			{
				Name = inputUserDTO.Name,
				Email = inputUserDTO.Email,
				Phone = inputUserDTO.Phone
			};
			await _dbContext.Users.AddAsync(userEntity);
			await _dbContext.SaveChangesAsync();
			outputUserDTO.Success = true;
			outputUserDTO.Id = userEntity.Id;
			outputUserDTO.Name = userEntity.Name;
			outputUserDTO.Phone = userEntity.Phone;
			outputUserDTO.Email = userEntity.Email;
			return outputUserDTO;
		}

		public async Task<OutputUserDTO> UpdateUserAsync(int id, InputUserDTO inputUserDTO)
		{
			OutputUserDTO outputUserDTO = new OutputUserDTO() { Success = false };
			UserEntity ?userEntity = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
			
			if (userEntity == null)
				return outputUserDTO;
			userEntity.Name = inputUserDTO.Name;
			userEntity.Email = inputUserDTO.Email;
			userEntity.Phone = inputUserDTO.Phone;
			await _dbContext.SaveChangesAsync();
			outputUserDTO.Id = id;
			outputUserDTO.Name = inputUserDTO.Name;
			outputUserDTO.Email = inputUserDTO.Email;
			outputUserDTO.Phone = inputUserDTO.Phone;
			outputUserDTO.Success = true;
			return outputUserDTO;
		}

		public async Task<bool> DeleteUserAsync(int id)
		{
			UserEntity? userEntity;

			userEntity = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
			if (userEntity == null)
				return false;
			_dbContext.Users.Remove(userEntity);
			await _dbContext.SaveChangesAsync();
			return true;
		}

		public async Task<OutputUserDTO> GetUserByIdAsync(int id)
		{
			OutputUserDTO outputUserDTO = new OutputUserDTO();
			UserEntity? userEntity;

			userEntity = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
			if (userEntity == null)
			{
				outputUserDTO.Success = false;
				return outputUserDTO;
			}
			outputUserDTO.Name = userEntity.Name;
			outputUserDTO.Email = userEntity.Email;
			outputUserDTO.Phone = userEntity.Phone;
			outputUserDTO.Success = true;
			return outputUserDTO;
		}

		public async Task<List<OutputUserDTO>> GetUsersAsync()
		{
			List<OutputUserDTO> listOutputUsersDTO = new List<OutputUserDTO>();
			List<UserEntity>    listUserEntities = await _dbContext.Users.ToListAsync();

			if (listUserEntities.Count <= 0)
				return listOutputUsersDTO;
			foreach(var user in listUserEntities)
			{
				OutputUserDTO outputUserDTO = new ()
				{
					Id = user.Id,
					Name = user.Name,
					Email = user.Email,
					Phone = user.Phone,
					Success = true
				};
				listOutputUsersDTO.Add(outputUserDTO);
			}	
			return listOutputUsersDTO;
		}

		public async Task<bool>				ExistsEmail(string email)
		{
			return await _dbContext.Users.AnyAsync(x => x.Email == email);
		}

		public async Task<bool>				ExistsPhone(string phone)
		{
			return await _dbContext.Users.AnyAsync(x => x.Phone == phone);
		}
	}
}

