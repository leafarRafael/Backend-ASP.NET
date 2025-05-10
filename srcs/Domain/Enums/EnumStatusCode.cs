using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ApiCRUD.srcs.Domain.Enums
{
	public enum EnumStatusCode
	{
		[Display(Name = "Ok")]
		[Description("Request completed successfully.")]
		Ok = 200,


		[Display(Name = "Created")]
		[Description("The request succeeded, and a new resource was created as a result.")]
		Created = 201,

		[Display(Name = "No Content")]
		[Description("There is no content to return for this request.")]
		NoContent = 204,

		[Display(Name = "NotFound")]
		[Description("Element not found, check parameters and try again.")]
		NotFound = 404,


		[Display(Name = "Not Acceptable")]
		[Description("No content was found that matches the criteria provided by the user agent.")]
		NotAcceptable = 406,

		[Display(Name = "Conflict")]
		[Description("Already registered.")]
		Conflict = 409,

		[Display(Name = "Content Too Large")]
		[Description("The request body is larger than the limits set by the server.")]
		ContentTooLarge = 413,
	}
}

