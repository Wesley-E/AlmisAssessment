// WARNING
//
// This file has been generated automatically by Rider IDE
//   to store outlets and actions made in Xcode.
// If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace AlmisAssessment
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		AppKit.NSTextField ClickedLabel { get; set; }

		[Action ("ClickedButton:")]
		partial void ClickedButton (Foundation.NSObject sender);

		void ReleaseDesignerOutlets ()
		{
			if (ClickedLabel != null) {
				ClickedLabel.Dispose ();
				ClickedLabel = null;
			}

		}
	}
}
