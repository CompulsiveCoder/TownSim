﻿using System;
using townsim.Engine.Entities;

namespace townsim.Engine.Needs
{
    public class ShelterNeedIdentifier : BaseNeedIdentifier
    {
        public ShelterNeedIdentifier (EngineSettings settings)
            : base(ItemType.Shelter, settings)
        {
        }

        public override bool IsNeeded (Person person)
        {
            return person.IsHomeless;
        }

        public override void RegisterNeed(Person person, ItemType needType, decimal quantity, decimal priority)
        {
            if (!NeedIsRegistered (person, needType, quantity)) {
                person.AddNeed (needType, quantity, priority);
            }
        }
    }
}
