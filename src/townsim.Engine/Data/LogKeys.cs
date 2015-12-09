﻿using System;
using datamanager.Data;

namespace townsim.Data
{
	public class LogKeys
	{
		public LogKeys ()
		{
		}

		public string GetLogKey(string engineId)
		{
			return DataConfig.Prefix + "-Log-" + engineId;
		}
	}
}
