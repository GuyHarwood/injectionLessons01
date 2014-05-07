using System;

namespace MyComponents.Contacts
{
	public class CreateContactCommand : Command
	{
		public Guid ContactId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
	}
}