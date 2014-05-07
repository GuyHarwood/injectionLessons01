using System.Collections.Generic;
using System.Data;
using Dapper;

namespace ContactManager.Contacts
{
	public interface IContactRepository
	{
		IEnumerable<Contact> GetContacts();
	}

	public class ContactRepository : IContactRepository
	{
		private readonly IDbConnection connection;

		public ContactRepository(IDbConnection connection)
		{
			this.connection = connection;
		}

		public IEnumerable<Contact> GetContacts()
		{
			return connection.Query<Contact>("SELECT * FROM dbo.Contact ORDER BY Name");
		}
	}
}