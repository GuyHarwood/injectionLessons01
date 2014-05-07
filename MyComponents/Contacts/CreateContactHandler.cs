using System.Data;
using Core;

namespace ContactManager.Contacts
{
	public class CreateContactHandler : ICommandHandler<CreateContactCommand>
	{
		private readonly Logger logger;
		private readonly IDbCommand dbCommand;

		public CreateContactHandler(Logger logger, IDbCommand command)
		{
			this.logger = logger;
			this.dbCommand = command;
		}

		public void Handle(CreateContactCommand command)
		{
			logger.Log("Creating Contact {0}", command.Name);

			this.dbCommand.CommandText = "INSERT dbo.Contact (ContactId, [Name], [Active]) VALUES (@ContactId, @Name, @Active)";

			var contactIdParam = this.dbCommand.CreateParameter();
			contactIdParam.ParameterName = "ContactId";
			contactIdParam.Value = command.ContactId;
			this.dbCommand.Parameters.Add(contactIdParam);

			var nameParam = this.dbCommand.CreateParameter();
			nameParam.ParameterName = "Name";
			nameParam.Value = command.Name;
			this.dbCommand.Parameters.Add(nameParam);

			var activeParam = this.dbCommand.CreateParameter();
			activeParam.ParameterName = "Active";
			activeParam.Value = false;
			this.dbCommand.Parameters.Add(activeParam);

			this.dbCommand.ExecuteNonQuery();

		}
	}
}