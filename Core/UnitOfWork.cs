using System;
using System.Data;

namespace Core
{
	public class UnitOfWork
	{
		private readonly Logger logger;
		private readonly Guid id;
		private readonly IDbTransaction transaction;

		public UnitOfWork(IDbConnection owner, Logger logger)
		{
			this.logger = logger;
			transaction = owner.BeginTransaction();
			id = Guid.NewGuid();
			logger.Log("Unit of work created at {0} with Id:{1}", DateTime.Now.ToLongTimeString(), id);
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