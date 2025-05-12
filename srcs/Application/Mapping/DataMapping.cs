using System.Reflection;

namespace ApiCRUD.srcs.Application.Mapping
{
	public class ApplicationMapping <TOrigin, TDestine>
		where TOrigin : class, new()
		where TDestine : class, new()
	{
		public TDestine Map(TOrigin origin)
		{
			if (origin == null)
				return new TDestine();

			var propOrigin = typeof(TOrigin).GetProperties();
			var propDestin = typeof(TDestine).GetProperties();

			if (propOrigin.Length == 0)
				throw new ArgumentException("There are no properties to be mapped in " + typeof(TOrigin).Name);
			if (propDestin.Length == 0)
				throw new ArgumentException("There are no properties to be mapped in " + typeof(TDestine).Name);
			var destine = new TDestine();

			foreach (var prop in propOrigin)
			{
				var destProp = propDestin.FirstOrDefault(
					p => 
					p.Name == prop.Name &&
					p.PropertyType == prop.PropertyType &&
					p.CanWrite);
				if (destProp == null)
					continue ;
				var value = prop.GetValue(origin);
				destProp.SetValue(destine, value);
			}
			return destine;
		}
	}
}



