// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace Extra.iOS.Native
{
	[Register ("MainTableViewCell")]
	partial class MainTableViewCell
	{
		[Outlet]
		public UIKit.UILabel SubTitle { get; set; }

		[Outlet]
		public UIKit.UILabel TitleLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (TitleLabel != null) {
				TitleLabel.Dispose ();
				TitleLabel = null;
			}

			if (SubTitle != null) {
				SubTitle.Dispose ();
				SubTitle = null;
			}
		}
	}
}
