using System;
using townsim.Data;
using System.Threading;
using townsim.Entities;
using System.Collections.Generic;

namespace townsim.Engine
{
	public class PlayerDiedException : Exception
	{
		public PlayerDiedException() : base("The player died.")
		{
		}
	}

}

