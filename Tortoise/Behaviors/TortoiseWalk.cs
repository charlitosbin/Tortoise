using System;
using System.Text;
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
			StringBuilder str = new StringBuilder ("\n\n");

			if (CoordinateMoves != null) {
				for (int i = 1; i < CoordinateMoves.Count; i++) {
					var previousCoord = CoordinateMoves [i - 1];
					var currentCoord = CoordinateMoves [i];

					str.Append(GetStepString(previousCoord));
					str.Append (" -> ");
					str.Append (GetStepString (currentCoord));
					str.Append ("   ");
					str.Append (GetStepNumberAndDirection (i, steps [i-1], (CardinalPoints)((i-1) % 4)));
					str.Append ("\n");
				}

				return str.ToString ();
			} else {
				return "Oops you are a smart guy,trying to break the rules";
			}
		}

		private string GetStepNumberAndDirection(int move, int step, CardinalPoints cardinale)
		{
			StringBuilder str = new StringBuilder ();
			var moveString = "";
			var stepString = "";

			if (move == 1) {
				moveString = "{0}st move, ";
			} else if (move == 2) {
				moveString = "{0}nd move, ";
			} else if (move > 2) {
				moveString = "{0}th move, ";
			}

			if (step == 1) {
				stepString = "{1} step {2}";
			} else {
				stepString = "{1} steps {2}";
			}

			return str.Append(string.Format(moveString + stepString, move, step, cardinale.ToString())).ToString();

		}

		private string GetStepString(CoordModel coordModel)
		{
			return string.Format ("({0},{1})",coordModel.X, coordModel.Y);
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