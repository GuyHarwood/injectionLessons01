using System.Collections.Generic;
using ContactManager.Contacts;

namespace ContactManager.Web.Models
{
	public class ContactIndexModel
	{
		public IEnumerable<Contact> Contacts { get; set; }
	}
}