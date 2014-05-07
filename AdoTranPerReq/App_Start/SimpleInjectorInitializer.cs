using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Web.Mvc;
using ContactManager.Contacts;
using ContactManager.Web;
using Core;
using Core.Auditing;
using SimpleInjector;
using SimpleInjector.Extensions;
using SimpleInjector.Integration.Web.Mvc;

[assembly: WebActivator.PostApplicationStartMethod(typeof(SimpleInjectorInitializer), "Initialize")]

namespace ContactManager.Web
{
	public static class SimpleInjectorInitializer
	{
		/// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
		public static void Initialize()
		{
			// Did you know the container can diagnose your configuration? Go to: https://bit.ly/YE8OJj.
			var container = new Container();

			InitializeContainer(container);

			container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

			container.Verify();

			DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
		}

		private static void InitializeContainer(Container container)
		{
			container.RegisterPerWebRequest<IDbConnection>(CreateConnection);
			container.RegisterSingle<Logger>();
			container.Register<IDbCommand>(() => new SqlCommand(string.Empty,container.GetInstance<IDbConnection>() as SqlConnection));
			container.RegisterPerWebRequest<IContactRepository, ContactRepository>();
			container.RegisterManyForOpenGeneric(typeof(ICommandHandler<>), typeof(Contact).Assembly);
			container.RegisterDecorator(typeof (ICommandHandler<>), typeof (CommandAuditingHandler<>));
			container.RegisterSingle<UnitOfWork>();
		}

		private static IDbConnection CreateConnection()
		{
			var conString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
			var con = new SqlConnection(conString);
			con.Open();
			return con;
		}
	}
}