using System;

namespace ContactManager.Contacts
{
	public class Contact
	{
		public Guid ContactId { get; set; }
		public string Name { get; set; }
		public bool Active { get; set; }
	}
}