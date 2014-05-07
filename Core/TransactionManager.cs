using System;
using System.Data;

namespace Core
{
	public class TransactionManager
	{
		private readonly IDbTransaction transaction;
		private readonly Guid id;

		public TransactionManager(IDbConnection owner)
		{
			transaction = owner.BeginTransaction();
			id = Guid.NewGuid();
		}

		public string Id
		{
			get { return id.ToString("N"); }
		}

		public void Commit()
		{
			transaction.Commit();
		}

		public void Rollback()
		{
			transaction.Rollback();
		}
	}
}