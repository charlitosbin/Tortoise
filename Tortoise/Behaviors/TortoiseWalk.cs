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
			InitializeCoordinatesMoves ();

			if (steps != null) {
				for(int i = 0; i < steps.Length; i++){
					var step = steps [i];
					var cardinatePoint = (CardinalPoints)(i % 4);
					var previousStep = CoordinateMoves [i];

					var move = (NextMove (previousStep, step, cardinatePoint));
					CoordinateMoves.Add (move);
				}
			}
		}

		public override string ToString ()
		{
			if (CoordinateMoves != null) {
			} else {
				return "Oops you are a smart guy,trying to break the rules";
			}
		}

		private void InitializeCoordinatesMoves()
		{
			if (CoordinateMoves == null)
				CoordinateMoves = new List<CoordModel> ();
			else
				CoordinateMoves.Clear ();

			CoordinateMoves.Add (new CoordModel {
				X = 0,
				Y = 0
			});
		}

		private CoordModel NextMove(CoordModel firstMove, int secondMove,
			CardinalPoints coordinatePoint)
		{
			CoordModel result = new CoordModel ();

			if (firstMove != null) {
				switch (coordinatePoint) {
				case CardinalPoints.North:
					result.Y = (firstMove.Y + secondMove);
					result.X = firstMove.X;
					break;
				case CardinalPoints.East:
					result.X = (firstMove.X + secondMove);
					result.Y = firstMove.Y;
					break;
				case CardinalPoints.South:
					result.Y = (firstMove.Y - secondMove);
					result.X = firstMove.X;
					break;
				case CardinalPoints.West:
					result.X = (firstMove.X - secondMove);
					result.Y = firstMove.Y;
					break;
				}
			}
				
			return  result;
		}
	}
}