using System;
using System.Collections.Generic;

using Tortoise.Models;

namespace Tortoise.Behaviors
{
	public class TortoiseWalk
	{
		private int [] steps;

		public List<CoordModel> CoordinatesMoves { get; set; }

		public TortoiseWalk (int[] steps)
		{
			this.steps = steps;
		}

		public void ToirtoiseMoves()
		{
			if (CoordinatesMoves == null)
				CoordinatesMoves = new List<CoordModel> ();
			else
				CoordinatesMoves.Clear ();
			
			if (steps != null) {
				for(int i = 0; i < steps.Length; i++){
					if (i == 0) {
						CoordinatesMoves.Add(NextMove (null, steps [i], (CardinatesPoints)i % 4));
					} else {
						var previousStep = CoordinatesMoves [i - 1];
						CoordinatesMoves.Add(NextMove (previousStep, steps [i], (CardinatesPoints)i % 4));
					}
				}
			}
		}

		private CoordModel NextMove(CoordModel firstMove, int secondMove,
			CardinatesPoints coordinatePoint)
		{
			CoordModel result = new CoordModel();

			if (firstMove != null) {
				switch (coordinatePoint) {
				case CardinatesPoints.North:
					firstMove.Y += secondMove;
					break;
				case CardinatesPoints.East:
					firstMove.X += secondMove;
					break;
				case CardinatesPoints.South:
					firstMove.Y -= secondMove;
					break;
				case CardinatesPoints.West:
					firstMove.X -= secondMove;
					break;
				}
			} else {
				result.X = 0;
				result.Y = 0;
			}

			return result;
		}
	}
}