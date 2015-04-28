using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Raven.Client;
using Raven.Client.Document;

namespace MileagePro
{
	public class MvcApplication : HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			GlobalConfiguration.Configure(WebApiConfig.Register);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
		}

		public static readonly Lazy<IDocumentStore> Store = new Lazy<IDocumentStore>(CreateStore);

		public static IDocumentStore DocumentStore
		{
			get { return Store.Value; }
		}

		private static IDocumentStore CreateStore()
		{
			return new DocumentStore
			{
				ConnectionStringName = "RavenDB"
			}.Initialize();
		}
	}
}
