using System;
using datamanager.Data;

namespace tilesim.Data
{
	public class EngineKeys
	{
		public EngineKeys ()
		{
		}

		public string GetEngineIdsKey()
		{
			return DataConfig.Prefix + "-Engines-Ids";
		}

		public string GetInfoKey(Guid engineId)
		{
			return DataConfig.Prefix + "-Engine-" + engineId.ToString();
		}
	}
}
