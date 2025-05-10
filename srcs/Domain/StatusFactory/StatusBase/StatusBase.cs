using ApiCRUD.srcs.Domain.Enums;
using ApiCRUD.srcs.Domain.Extension;

namespace ApiCRUD.srcs.Domain.StatusFactory
{
	public class StatusBase
	{
		public EnumStatusCode	StatusCode { get; set; }
		public string 			ReasonPrase => EnumExtensions.GetDisplayName(StatusCode);
		public string?			Message =>EnumExtensions.GetDescription(StatusCode);

		public StatusBase(){}
	}
}