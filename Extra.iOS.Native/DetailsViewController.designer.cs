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
	[Register ("DetailsViewController")]
	partial class DetailsViewController
	{
		[Outlet]
		UIKit.UITableView DetailsTableView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (DetailsTableView != null) {
				DetailsTableView.Dispose ();
				DetailsTableView = null;
			}
		}
	}
}
