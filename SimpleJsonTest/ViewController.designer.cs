// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace SimpleJsonTest
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		AppKit.NSComboBox cbMethod { get; set; }

		[Outlet]
		AppKit.NSTextField lbResponse { get; set; }

		[Outlet]
		AppKit.NSTextField txtMimeType { get; set; }

		[Outlet]
		AppKit.NSTextView txtRequest { get; set; }

		[Outlet]
		AppKit.NSTextField txtServer { get; set; }

		[Action ("butGo:")]
		partial void butGo (Foundation.NSObject sender);

		[Action ("lstChange:")]
		partial void lstChange (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (txtServer != null) {
				txtServer.Dispose ();
				txtServer = null;
			}

			if (cbMethod != null) {
				cbMethod.Dispose ();
				cbMethod = null;
			}

			if (lbResponse != null) {
				lbResponse.Dispose ();
				lbResponse = null;
			}

			if (txtRequest != null) {
				txtRequest.Dispose ();
				txtRequest = null;
			}

			if (txtMimeType != null) {
				txtMimeType.Dispose ();
				txtMimeType = null;
			}
		}
	}
}
