using System;
using System.Collections.Generic;

using Tortoise.Models;

namespace Tortoise.Behaviors
{
	public class TortoiseWalk
	{
		private int [] steps;

		public TortoiseWalk (int[] steps)
		{
			this.steps = steps;
		}

		public void ToirtoiseMoves()
		{
			List<CoordModel> coordinatesMoves = new List<CoordModel> ();
			if (steps != null) {
				for(int i = 0; i < steps.Length; i++){
					if (i == 0) {
						coordinatesMoves.Add(coordinatesMoves(NextMove (null, steps [0], (CardinatesPoints)i % 4)));
					} else {
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