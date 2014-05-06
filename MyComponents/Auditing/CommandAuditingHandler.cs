namespace MyComponents.Auditing
{
	public class CommandAuditingHandler : ICommandHandler<Command>
	{
		private readonly ICommandHandler<Command> handlerToAudit;

		public CommandAuditingHandler(ICommandHandler<Command> handlerToAudit)
		{
			this.handlerToAudit = handlerToAudit;
		}

		public void Execute(Command command)
		{
			//TODO read all properties, create audit entry
			handlerToAudit.Execute(command);
		}
	}
}