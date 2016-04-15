using System;

using UIKit;
using Tortoise.Behaviors;



namespace Tortoise
{
	public partial class ViewController : UIViewController
	{

		private int [] stepsArray;
		TortoiseWalk tortoise;

		public ViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			InitializeVariables ();
			tortoise.TortoiseMoves ();
			Console.WriteLine (tortoise.ToString ());
		}

		private void InitializeVariables()
		{
			stepsArray = new int[] {1, 3, 2, 5, 4, 4, 6, 3, 2};
			tortoise = new TortoiseWalk (stepsArray);
				
		}
	}
}

