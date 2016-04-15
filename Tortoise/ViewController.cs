using System;

using UIKit;



namespace Tortoise
{
	public partial class ViewController : UIViewController
	{

		private int [] StepsArray;

		public ViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			InitializeVariables ();
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}

		private void InitializeVariables()
		{
			StepsArray = new int[0, 1, 3, 2, 5, 4, 4, 6, 3, 2];
				
		}
	}
}

