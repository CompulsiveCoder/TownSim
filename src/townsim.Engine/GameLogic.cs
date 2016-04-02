﻿using System;
using System.Runtime.Remoting.Messaging;
using System.Collections.Generic;

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
	}
}
