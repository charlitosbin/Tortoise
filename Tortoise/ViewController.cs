using System;

using UIKit;
using Tortoise.Behaviors;



namespace Tortoise
{
	public partial class ViewController : UIViewController
	{

		private int [] stepsArray;
		TortoiseWalk tortoise;

		private UITextView txtResult;

		public ViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			InitializeVariables ();
			AddUIProperties ();
			tortoise.TortoiseMoves ();

			txtResult.Text = tortoise.ToString ();

			Console.WriteLine (tortoise.ToString ());
		}

		private void InitializeVariables()
		{
			stepsArray = new int[] {1, 3, 2, 5, 4, 4, 6, 3, 2};
			tortoise = new TortoiseWalk (stepsArray);

			txtResult = new UITextView ();

			this.View.AddSubview (txtResult);
		}

		private void AddUIProperties()
		{
			txtResult.Frame = new CoreGraphics.CGRect (0, 0, this.View.Bounds.Size.Width, this.View.Bounds.Size.Height);
		}
	}
}