using System;

namespace Core
{
	public class UnitOfWork
	{
		private readonly Guid id;

		public UnitOfWork(Logger logger)
		{
			id = Guid.NewGuid();
			logger.Log("Unit of work created at {0} with Id:{1}", DateTime.Now.ToLongTimeString(), id);
		}

		public string Id
		{
			get { return id.ToString("N"); }
		}
	}
}