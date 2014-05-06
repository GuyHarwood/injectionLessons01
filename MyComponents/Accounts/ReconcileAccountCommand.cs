using System;

namespace MyComponents.Accounts
{
	public class ReconcileAccountCommand : Command
	{
		public Guid AccountId { get; set; }
		public string RequestedBy { get; set; }
	}
}