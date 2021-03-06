﻿using System;
using tilesim.Engine.Entities;
using tilesim.Engine.Activities;

namespace tilesim.Engine
{
    public class SleepNeedIdentifier : BaseNeedIdentifier
    {
        public SleepNeedIdentifier (EngineSettings settings, ConsoleHelper console)
            : base(ActivityVerb.Sleep, ItemType.NotSet, PersonVitalType.Energy, settings, console)
        {
        }

        public override bool IsNeeded (Person person)
        {
            return person.Vitals[PersonVitalType.Energy] <= Settings.EnergySleepThreshold;
        }

        public override void RegisterNeed(Person person, ActivityVerb actionType, ItemType itemType, PersonVitalType vitalType, decimal priority)
        {
            var quantity = 100 - person.Vitals[PersonVitalType.Energy];

            if (!NeedIsRegistered (person, actionType, itemType, vitalType, quantity)) {
                AddNeed (actionType, itemType, vitalType, quantity, priority);
            }
        }
    }
}

