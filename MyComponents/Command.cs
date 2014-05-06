using System;

namespace MyComponents
{
	public abstract class Command
	{
		protected Command()
		{
			CommandId = Guid.NewGuid();
			CreatedAtUtc = DateTime.UtcNow;
		}

		public Guid CommandId { get; private set; }
		public DateTime CreatedAtUtc { get; private set; }
	}
}