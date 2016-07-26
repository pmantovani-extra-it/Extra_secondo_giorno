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
	[Register ("MainViewController")]
	partial class MainViewController
	{
		[Outlet]
		UIKit.UITableView PostTableView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (PostTableView != null) {
				PostTableView.Dispose ();
				PostTableView = null;
			}
		}
	}
}
