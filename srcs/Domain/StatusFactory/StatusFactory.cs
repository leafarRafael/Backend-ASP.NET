using ApiCRUD.srcs.Domain.Enums;

namespace ApiCRUD.srcs.Domain.StatusFactory
{
	public static class StatusFactory
	{
		static public StatusBase Ok()
			=> new StatusBase() { StatusCode = EnumStatusCode.Ok};

		static public StatusBase Created()
			=> new StatusBase() { StatusCode = EnumStatusCode.Created};

		static public StatusBase NotFound() 
			=> new StatusBase() { StatusCode = EnumStatusCode.NotFound};

		static public StatusBase NotAcceptable()
			=> new StatusBase() { StatusCode = EnumStatusCode.NotAcceptable};
		
		static public StatusBase Conflict() 
			=> new StatusBase() { StatusCode = EnumStatusCode.Conflict};

		static public StatusBase ContentTooLarge() 
			=> new StatusBase() { StatusCode = EnumStatusCode.ContentTooLarge};


		static public StatusBase NoContent() 
			=> new StatusBase() { StatusCode = EnumStatusCode.Ok };
	}
}
