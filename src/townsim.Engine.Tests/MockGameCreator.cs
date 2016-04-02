﻿using System;
using townsim.Engine.Entities;
using datamanager.Data;
using datamanager.Data.Tests;

namespace townsim.Engine.Tests
{
	public class MockGameCreator
	{
		public EngineSettings Settings { get;set; }

		public MockGameCreator (EngineSettings settings)
		{
			Settings = settings;
		}

		public EngineContext Create()
		{
			var data = CreateDataManager ();

			var context = new MockEngineContext (Settings, data);

			var process = CreateProcess (context);

			// Attach the process to the context
			context.AttachProcess(process);

			return context;
		}

		public EngineProcess CreateProcess(EngineContext context)
		{
			var process = new EngineProcess (context);

			return process;
		}

		public DataManager CreateDataManager()
		{
            var dataManager = new DataManager(new MockRedisClientWrapper());

			dataManager.IsVerbose = Settings.IsVerbose;

			return dataManager;
		}
	}
}

