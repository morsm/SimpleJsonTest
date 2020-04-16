using System;
using System.Threading.Tasks;

using AppKit;
using Foundation;

namespace SimpleJsonTest
{
    public partial class ViewController : NSViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            this.cbMethod.SelectItem(1); // POST

            // Disable smart quote substitution, which messes up JSON
            txtRequest.AutomaticQuoteSubstitutionEnabled = false;
        }

        public override NSObject RepresentedObject
        {
            get
            {
                return base.RepresentedObject;
            }
            set
            {
                base.RepresentedObject = value;
                // Update the view, if already loaded.
            }
        }

        partial void butGo(NSObject sender)
        {
            var url = txtServer.StringValue;

            if (IsPost)
            {
                // Get data to send
                var content = txtRequest.String;
                var mime = txtMimeType.StringValue;

                // Run the request asynchronously
                Task.Run(async () =>
                {
                    var result = await JsonClient.Post(url, content, mime);

                    // On UI thread, fill text box
                    InvokeOnMainThread(() =>
                    {
                        lbResponse.StringValue = result;
                    });
                });
            }
            else
            {
                // Run the request asynchronously
                Task.Run(async () =>
                {
                    var result = await JsonClient.Get(url);

                    // On UI thread, fill text box
                    InvokeOnMainThread(() =>
                    {
                        lbResponse.StringValue = result;
                    });
                });
            }
        }

        partial void lstChange(NSObject sender)
        {
            // Disable content and MIME type on GET
            txtRequest.Editable =
            txtMimeType.Editable = IsPost;
        }

        private bool IsPost
        {
            get { return cbMethod.SelectedIndex == 1; }
        }
    }
}
