﻿using System;
using townsim.Engine.Entities;
using datamanager.Entities;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Xml.Serialization;

namespace townsim.Engine
{
	[Serializable]
	[JsonObject(IsReference = true)]
    public partial class GameTile : IHasInventory
	{
		[TwoWay("Tile")]
		public Plant[] Plants { get; set; }

		[TwoWay("People")]
		public Person[] People { get; set; }

		[JsonIgnore]
		[XmlIgnore]
		[NonSerialized]
		public GameEnvironment World;

        public Inventory Inventory { get; set; }

        public EngineSettings Settings { get;set; }

		public GameTile (GameEnvironment world, EngineSettings settings)
		{
			World = world;
			Plants = new Plant[]{ };
			People = new Person[]{ };
            Inventory = new Inventory(this, null, Settings);
		}

		public void AddPerson(Person person)
		{
			AddPeople (person);
		}

		public void AddPeople(params Person[] people)
		{
			var list = new List<Person> (People);
			list.AddRange (people);
			People = list.ToArray ();

			World.AddPeople (people);

			foreach (var person in people)
				person.Tile = this;
		}

		public void AddTrees(Plant[] trees)
		{
			var list = new List<Plant> (Plants);
			list.AddRange (trees);
			Plants = list.ToArray ();

			World.AddTrees (trees);

			foreach (var tree in trees)
				tree.Tile = this;
		}

		public void RemovePlant(Plant plant)
		{
			var list = new List<Plant> (Plants);
			list.Remove (plant);
			Plants = list.ToArray ();
		}
	}
}

