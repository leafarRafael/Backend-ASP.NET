using System.ComponentModel.DataAnnotations;

namespace ApiCRUD.srcs.Domain.DTOs
{
	public class OutputUserDTO
	{

		[Required]
		public bool		Success { get; set; } = false;

		[Required]
		public int		Id { get; set; }

		[Required]
		[MaxLength(256)]
		public string?	Name { get; set; }


		[Required]
		[MaxLength(50)]
		[Phone]
		public string?	Phone { get; set; }


		[Required]
		[MaxLength(50)]
		[EmailAddress]
		public string?	Email { get; set; }
	}
}
