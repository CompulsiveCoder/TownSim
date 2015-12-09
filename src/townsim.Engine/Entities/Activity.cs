using System;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace townsim.Entities
{
	public enum ActivityType
	{
		Inactive = 0,
		Eating,
		Drinking,
		Builder,
		Forestry,
		Gardening,
		Harvesting,
		CollectingWater
	}

}
