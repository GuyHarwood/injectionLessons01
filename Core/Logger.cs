using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Core
{
	public class Logger
	{
		private static readonly ConcurrentBag<string> Logs;

		static Logger()
		{
			Logs = new ConcurrentBag<string>();
		}

		public void Log(string message)
		{
			Logs.Add(string.Format("{0} - {1}", DateTime.Now.ToShortTimeString(), message));
		}

		public void Log(string format, params object[] args)
		{
			Log(string.Format(format,args));
		}

		public IEnumerable<string> CurrentSnapshot()
		{
			return Logs.ToArray();
		}
	}
}