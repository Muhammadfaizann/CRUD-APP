using Foundation;
using MeApp.Helper;
using SampleApp.iOS.Renderrer;
using System.Threading;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(MessageiOS))]
namespace SampleApp.iOS.Renderrer
{
    class MessageiOS : IMessage
    {
        const double LONG_DELAY = 4.0;
        const double SHORT_DELAY = 1.5;

        NSTimer alertDelay;

        UIAlertController alert;

        public void ExitApp()
        {
            Thread.CurrentThread.Abort();
        }

        public void LongAlert(string message)
        {
            ShowAlert(message, LONG_DELAY);
        }

        public void ShortAlert(string message)
        {
            ShowAlert(message, SHORT_DELAY);
        }
        void ShowAlert(string message, double seconds)
        {
            alertDelay = NSTimer.CreateScheduledTimer(seconds, (obj) =>
            {
                dismissMessage();
            });

            alert = UIAlertController.Create(null, message, UIAlertControllerStyle.Alert);
            UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(alert, true, null);
        }
        void dismissMessage()
        {
            if (alert != null)
            {
                alert.DismissViewController(true, null);
            }
            if (alertDelay != null)
            {
                alertDelay.Dispose();
            }
        }
    }
}