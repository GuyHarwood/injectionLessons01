using System;
using System.Collections.Generic;

namespace MyComponents
{
	public class Auditer
	{
		private static readonly List<string> Logs;

		static Auditer()
		{
			Logs = new List<string>();
		}

		public void Log(string message)
		{
			Logs.Add(string.Format("{0} - {1}", DateTime.Now.ToShortTimeString(), message));
		}

		public IEnumerable<string> CurrentSnapshot()
		{
			return Logs.ToArray();
		}
	}
}