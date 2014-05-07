using System.Web.Mvc;
using Core;

namespace ContactManager.Web
{
	public class Bus
	{
		public void Dispatch<TCommand>(TCommand command) where TCommand : Command
		{
			//use the MVC dependency resolver as this will utilise the underlying container
			var handler = DependencyResolver.Current.GetService<ICommandHandler<TCommand>>();
			handler.Handle(command);
		}
	}
}
