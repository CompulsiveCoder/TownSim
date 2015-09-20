﻿using System;
using townsim.Entities;

namespace townsim.Engine
{
	public class ThirstEngine
	{
		public decimal WaterConsumptionRate = 0.3m; // liters
		public decimal ThirstSatisfactionRate = 1; // The rate at which thirst is reduced

		public decimal ThirstRate = 100m / (24*60*60) * 5m; // 100% / seconds in a day * drinks per day

		public EngineSettings Settings { get;set; }

		public ThirstEngine (EngineSettings settings)
		{
			Settings = settings;
		}

		public void Update(Person person)
		{
			if (person.IsAlive)
			{
				UpdateThirst (person);
				UpdateWaterConsumption (person);
			}
		}

		public void UpdateThirst(Person person)
		{
			person.Thirst += ThirstRate * Settings.GameSpeed;

			if (person.Thirst > 100)
				person.Thirst = 100;
		}

		public void UpdateWaterConsumption(Person person)
		{
			var randomiser = new Random ().Next (200);

			var decider = randomiser < person.Thirst;
			if (person.Thirst >= 99)
				decider = true;

			if (decider) {
				var amountOfWaterRequired = person.Thirst / ThirstSatisfactionRate;

				var amountConsumed = amountOfWaterRequired * WaterConsumptionRate * Settings.GameSpeed;
				if (person.Location.WaterSources > 0) {
					if (amountConsumed > person.Location.WaterSources)
						amountConsumed = person.Location.WaterSources;
					if (amountConsumed > person.Thirst)
						amountConsumed = person.Thirst / ThirstSatisfactionRate;
					
					person.Location.WaterSources -= amountConsumed;
					person.Thirst -= amountConsumed * ThirstSatisfactionRate;
				}
			}

			if (person.Thirst < 0)
				person.Thirst = 0;
		}
	}
}
