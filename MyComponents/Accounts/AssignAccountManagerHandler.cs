using System.Data;

namespace MyComponents.Accounts
{
	public class AssignAccountManagerHandler : ICommandHandler<AssignAccountManagerCommand>
	{
		private readonly IDbCommand dbCommand;

		public AssignAccountManagerHandler(IDbCommand dbCommand)
		{
			this.dbCommand = dbCommand;
		}

		public void Execute(AssignAccountManagerCommand command)
		{
			dbCommand.CommandText = "INSERT dbo.Contact (ContactId, [Name], [Active]) VALUES (@ContactId, @Name, @Active)";

			var contactIdParam = dbCommand.CreateParameter();
			contactIdParam.ParameterName = "@ContactId";
			contactIdParam.Value = command.AccountId;
			dbCommand.Parameters.Add(contactIdParam);

			var nameParam = dbCommand.CreateParameter();
			nameParam.ParameterName = "@Name";
			nameParam.Value = command.UserId;
			dbCommand.Parameters.Add(nameParam);

			var activeParam = dbCommand.CreateParameter();
			activeParam.ParameterName = "@Active";
			activeParam.Value = false;
			dbCommand.Parameters.Add(activeParam);

			dbCommand.ExecuteNonQuery();
		}
	}
}