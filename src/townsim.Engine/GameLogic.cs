﻿using System;
using System.Runtime.Remoting.Messaging;
using System.Collections.Generic;
using townsim.Engine.Activities;
using townsim.Engine.Needs;
using townsim.Engine.Entities;

namespace townsim.Engine
{
	[Serializable]
	public class GameLogic
	{
		public ActivityInfo[] Activities { get; set; }
		public BaseNeedIdentifier[] Needs { get; set; }

		public GameLogic ()
		{
			Needs = new BaseNeedIdentifier[]{ };
			Activities = new ActivityInfo[]{ };
		}

		public void AddNeed(BaseNeedIdentifier need)
		{
			var list = new List<BaseNeedIdentifier> ();
			if (Needs != null)
				list.AddRange (Needs);
			list.Add(need);
			Needs = list.ToArray ();
		}

		public void AddActivity(Type activityType)
		{
			var activityInfo = new ActivityInfo (activityType);

			var list = new List<ActivityInfo> ();
			if (Activities != null)
				list.AddRange (Activities);
			list.Add(activityInfo);
			Activities = list.ToArray ();
		}

        static public GameLogic NewComplete(EngineSettings settings)
        {
            var logic = new GameLogic ();

            logic.AddNeed (new ShelterNeedIdentifier (settings));
            logic.AddNeed (new DrinkNeedIdentifier (settings));
            logic.AddNeed (new MealNeedIdentifier (settings));

            logic.AddActivity (typeof(BuildShelterActivity));
            logic.AddActivity (typeof(MillTimberActivity));
            logic.AddActivity (typeof(FellWoodActivity));
            logic.AddActivity (typeof(EatMealActivity));
            logic.AddActivity (typeof(GatherFoodActivity));
            logic.AddActivity (typeof(CollectWaterActivity));
            logic.AddActivity (typeof(DrinkWaterActivity));

            return logic;
        }
	}
}

