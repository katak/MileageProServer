using System.Web.Http;

namespace MileagePro
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/v1/{controller}/{id}",
				defaults: new {id = RouteParameter.Optional}
			);
		}
	}
}