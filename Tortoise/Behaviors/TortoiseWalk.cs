using System;
using System.Collections.Generic;

using Tortoise.Models;

namespace Tortoise.Behaviors
{
	public class TortoiseWalk
	{
		private int [] steps;

		public List<CoordModel> CoordinateMoves { get; set; }

		public TortoiseWalk (int[] steps)
		{
			this.steps = steps;
		}

		public void TortoiseMoves()
		{
			if (CoordinateMoves == null)
				CoordinateMoves = new List<CoordModel> ();
			else
				CoordinateMoves.Clear ();
			
			if (steps != null) {
				for(int i = 0; i < steps.Length; i++){
					var step = steps [i];
					var cardinatePoint = (CardinalPoints)(i % 4);
					if (i == 0) {
						CoordinateMoves.Add(NextMove (null, step, cardinatePoint));
					} else {
						var previousStep = CoordinateMoves [i - 1];
						CoordinateMoves.Add(NextMove (previousStep, step, cardinatePoint));
					}
				}
			}
		}

		private CoordModel NextMove(CoordModel firstMove, int secondMove,
			CardinalPoints coordinatePoint)
		{
			CoordModel result = new CoordModel();

			if (firstMove != null) {
				switch (coordinatePoint) {
				case CardinalPoints.North:
					firstMove.Y += secondMove;
					break;
				case CardinalPoints.East:
					firstMove.X += secondMove;
					break;
				case CardinalPoints.South:
					firstMove.Y -= secondMove;
					break;
				case CardinalPoints.West:
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