using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyComponents
{
	public interface ICommandHandler<in TCommand> where TCommand : CommandBase
	{
		void Execute(TCommand command);
	}

	public class CommandBase
	{
	}
}
