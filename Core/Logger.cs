using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Core
{
	public class Logger
	{
		private readonly ConcurrentBag<string> logs;

		public Logger()
		{
			logs = new ConcurrentBag<string>();
		}

		public void Log(string message)
		{
			logs.Add(string.Format("{0} - {1}", DateTime.Now.ToLongTimeString(), message));
		}

		public void Log(string format, params object[] args)
		{
			Log(string.Format(format,args));
		}

		public IEnumerable<string> CurrentSnapshot()
		{
			return logs.ToArray();
		}
	}
}