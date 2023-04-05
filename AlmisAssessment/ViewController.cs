using System;
using AppKit;
using Foundation;

namespace AlmisAssessment
{
    public partial class ViewController : NSViewController
    {
        private int numberOfTimesClicked = 0;
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            ClickedLabel.StringValue = "Button not clicked";
        }

        partial void ClickedButton(NSObject sender)
        {
            ClickedLabel.StringValue =
                $"The button has been clicked {++numberOfTimesClicked} time{(numberOfTimesClicked < 2 ? "" : "s")}.";
        }

        public override NSObject RepresentedObject
        {
            get { return base.RepresentedObject; }
            set
            {
                base.RepresentedObject = value;
                // Update the view, if already loaded.
            }
        }
    }
}