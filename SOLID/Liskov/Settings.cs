using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.Liskov
{
	public interface IPersistedSettings
	{
		void Load();
		void Save();
	}

	public class GlobalSettings : IPersistedSettings
	{
		public void Load()
		{
			//load global config file
		}

		public void Save()
		{
			//save to global config
		}
	}

	public class UserSettings : IPersistedSettings
	{
		public void Load()
		{
			//load user settings
		}

		public void Save()
		{
			//save user settings
		}
	}

	public class ImpersonatedUserSettings : IPersistedSettings
	{
		public void Load()
		{
			//load other users specific settings
		}

		public void Save()
		{
			throw new NotImplementedException("we never persist impersonation because its scoped to one session only");
		}
	}

	public class SettingsService
	{
		public IEnumerable<IPersistedSettings> LoadAll(IEnumerable<IPersistedSettings> settingsBatch)
		{
			foreach (var settings in settingsBatch)
			{
				settings.Load();
			}

			return settingsBatch;
		}

		public void SaveAll(IEnumerable<IPersistedSettings> settingsBatch)
		{
			foreach (var settings in settingsBatch)
			{
				settings.Save();
			}
		}
	}
}
