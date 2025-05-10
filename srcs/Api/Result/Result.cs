namespace ApiCRUD.srcs.Api.Result
{
	public class Result<TData, TStatus, TLinks>
	{
		public TStatus?			Status { get; set; } = default!;
        public TData?			Data { get; set; } = default!;
        public TLinks?			Links { get; set; } = default!;

		public static Result<TData, TStatus, TLinks> Ok(TData data, TStatus status, TLinks link)
			=> new()
		{
			Data = data,
			Status = status,
			Links = link 
		};

		public static Result<TData, TStatus, TLinks> Fail(TStatus status)
			=> new ()
		{
			Status = status
		};

	}

}

