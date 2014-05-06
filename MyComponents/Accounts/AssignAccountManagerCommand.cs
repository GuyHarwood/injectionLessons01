using System;

namespace MyComponents.Accounts
{
	public class AssignAccountManagerCommand : Command
	{
		public Guid AccountId { get; set; }
		public Guid UserId { get; set; }
	}

	public enum AccountAccessLevel
	{
		ReadOnly,
		Manager
	}
}