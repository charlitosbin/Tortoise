using System;

namespace Tortoise.Models
{
	public class CoordModel
	{

		public int X { get; set;}
		public int Y { get; set;}

		public CoordModel (){}
	}

	public enum CardinalPoints{
		North,
		East,
		South,
		West
	}
}