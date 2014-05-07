using System.Data;
using Newtonsoft.Json;

namespace Core.Auditing
{
	public class CommandAuditingHandler<TCommand> : ICommandHandler<TCommand> where TCommand : Command
	{
		private readonly ICommandHandler<TCommand> handlerToAudit;
		private readonly IDbCommand dbCommand;

		public CommandAuditingHandler(ICommandHandler<TCommand> handlerToAudit, IDbCommand dbCommand)
		{
			this.handlerToAudit = handlerToAudit;
			this.dbCommand = dbCommand;
		}

		public void Handle(TCommand command)
		{
			const string sql = @"INSERT INTO [dbo].[Audit]
									([CommandId], [CommandType], [CommandData], [CreatedAt])
								VALUES 
									(@CommandId, @CommandType, @CommandData, GETUTCDATE())";
			
			var commandIdParam = dbCommand.CreateParameter();
			commandIdParam.ParameterName = "CommandId";
			commandIdParam.Value = command.CommandId;
			dbCommand.Parameters.Add(commandIdParam);

			var commandTypeParam = dbCommand.CreateParameter();
			commandTypeParam.ParameterName = "CommandType";
			commandTypeParam.Value = command.GetType().ToString();
			dbCommand.Parameters.Add(commandTypeParam);

			var data = JsonConvert.SerializeObject(command);
			var commandDataParam = dbCommand.CreateParameter();
			commandDataParam.ParameterName = "CommandData";
			commandDataParam.Value = data;
			dbCommand.Parameters.Add(commandDataParam);

			dbCommand.CommandText = sql;
			dbCommand.CommandType = CommandType.Text;
			dbCommand.ExecuteNonQuery();

			handlerToAudit.Handle(command);
		}
	}
}