using System;
using tilesim.Engine.Entities;

namespace tilesim.Engine.Needs
{
    public class DrinkWaterNeedIdentifier : BaseNeedIdentifier
    {
        public DrinkWaterNeedIdentifier (EngineSettings settings, ConsoleHelper console)
            : base(ActivityType.Drink, ItemType.Water, PersonVitalType.Thirst, settings, console)
        {
        }

        public override bool IsNeeded (Person person)
        {
            return person.Vitals[PersonVitalType.Thirst] > Settings.ThirstThreshold;
        }

        public override void RegisterNeed(Person person, ActivityType actionType, ItemType itemType, PersonVitalType vitalType, decimal priority)
        {
            var quantity = Settings.DefaultDrinkAmount;

            if (!NeedIsRegistered (person, actionType, itemType, vitalType, quantity)) {
                AddNeed (actionType, itemType, vitalType, quantity, priority);
            }
        }
    }
}
