using System;
using NUnit.Framework;
using tilesim.Engine.Activities;
using tilesim.Engine.Entities;

namespace tilesim.Engine.Tests.Unit.Activities
{
    [TestFixture(Category="Unit")]
    public class DrinkWaterActivityUnitTestFixture : BaseEngineUnitTestFixture
    {
        [Test]
        public void Test_DrinkWater_WaterAvailable()
        {
            Console.WriteLine ("");
            Console.WriteLine ("Preparing test");
            Console.WriteLine ("");

            var context = MockEngineContext.New ();

            context.World.Logic.AddActivity (typeof(DrinkWaterActivity));

            var settings = context.Settings;

            settings.DefaultDrinkAmount = 10; // Increase the drink rate to speed up test

            var person = new Person (settings);
            person.Inventory [ItemType.Water] = 100;
            person.Vitals[PersonVitalType.Thirst] = 80;

            var needEntry = new NeedEntry (
                ActivityVerb.Drink,
                ItemType.Water,
                PersonVitalType.Thirst,
                settings.DefaultDrinkAmount,
                settings.DefaultItemPriorities[ItemType.Water]
            );

            var activity = new DrinkWaterActivity (person, needEntry, settings, new ConsoleHelper(settings));

            Console.WriteLine ("");
            Console.WriteLine ("Executing test");
            Console.WriteLine ("");

            activity.Act (person);

            Console.WriteLine ("");
            Console.WriteLine ("Analysing test");
            Console.WriteLine ("");

            Assert.AreEqual(70, person.Vitals[PersonVitalType.Thirst]);

        }
    }
}

