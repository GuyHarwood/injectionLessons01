namespace MyComponents.Contacts
{
	public class CreateContactHandler : ICommandHandler<CreateContactCommand>
	{
		private readonly Logger logger;

		public CreateContactHandler(Logger logger)
		{
			this.logger = logger;
		}

		public void Execute(CreateContactCommand command)
		{
			logger.Log("Creating Contact {0}", command.Name);
		}
	}
}