﻿using System;
using townsim.Engine.Entities;
using townsim.Data;

namespace townsim.Engine.Activities
{
	[Serializable]
    [Activity(ItemType.Water)]
	public class CollectWaterActivity : BaseActivity
	{
		public decimal CollectionRate = 50.0m;

        public decimal TotalWaterCollected = 0;
        		
        public CollectWaterActivity (Person actor, NeedEntry needEntry, EngineSettings settings) : base(actor, needEntry, settings)
		{
		}

        public override void Prepare (Person person)
        {
            throw new NotImplementedException ();
        }

        public override void Execute (Person person)
        {
            if (Settings.IsVerbose)
                Console.WriteLine ("Collecting water");

            var personCanHoldMoreWater = !person.Inventory.IsFull (ItemType.Water);

            var tileHasWater = person.Tile.Inventory.Items [ItemType.Water] > 0;

            if (tileHasWater && personCanHoldMoreWater) {
                var amountThisCycle = Settings.DefaultCollectWaterRate;

                var tile = person.Tile;

                AddTransfer (tile, person, ItemType.Water, amountThisCycle);

                TotalWaterCollected += amountThisCycle;
            } else {
                if (Settings.IsVerbose)
                    Console.WriteLine ("  The tile has no water.");
            }
        }

        public override bool CheckFinished ()
        {
            return TotalWaterCollected >= NeedEntry.Quantity;
        }

        public override void ConfirmProduced (NeedEntry entry)
        {
            base.ConfirmProduced (entry);
        }

        public override bool CheckRequiredItems (Person actor)
        {
            if (actor.Tile == null)
                throw new Exception ("actor.Tile property is null.");
            
            var waterAvailable = actor.Tile.Inventory.Items [ItemType.Water] > 0;

            if (!waterAvailable && Settings.IsVerbose)
                Console.WriteLine ("  No water available.");

            return waterAvailable;
        }

        // TODO: Clean up
		/*protected override void ExecuteSingleCycle()
		{
			if (Person.ActivityType == ActivityType.CollectingWater) {
				
			}
		}

		public override void Start ()
		{
			throw new NotImplementedException ();
		}

		public override bool CheckComplete ()
		{
			return Person.Supplies [SupplyTypes.Water] >= Person.SuppliesMax [SupplyTypes.Water];
		}

		public override bool CheckImpossible ()
		{
			throw new NotImplementedException ();
		}

		public override void Finish ()
		{
			throw new NotImplementedException ();
		}*/
	}
}