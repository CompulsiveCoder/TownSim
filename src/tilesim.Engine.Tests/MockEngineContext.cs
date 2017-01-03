using System;
using tilesim.Engine.Entities;
using datamanager.Data;
using Newtonsoft.Json;

namespace tilesim.Engine.Tests
{
    [Serializable]
    [JsonObject("EngineContext", IsReference=true)]
	public class MockEngineContext : EngineContext
	{
		public MockEngineContext (EngineProcess process) : base(process)
		{
			throw new NotImplementedException ();
		}

		public MockEngineContext(EngineSettings settings, DataManager data) : base(settings, data)
		{
			
		}

		public new static MockEngineContext New()
		{
            var settings = EngineSettings.DefaultVerbose;

            settings.CycleDuration = 1; // Set the duration to 1 millisecond so there's no delay during tests

            settings.PlayerSettings = PersonSettings.Autonomous; // Set to autonomous so all automatic functionality is executed during the test

			return new MockGameCreator (settings).Create ();
		}

        public static MockEngineContext New(EngineSettings settings)
        {
            return new MockGameCreator (settings).Create ();
        }
	}
}

