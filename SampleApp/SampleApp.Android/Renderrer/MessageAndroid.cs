using Android.App;
using Android.Widget;

using MeApp.Helper;
using Plugin.CurrentActivity;
using SampleApp.Droid.Renderrer;

[assembly: Xamarin.Forms.Dependency(typeof(MessageAndroid))]

namespace SampleApp.Droid.Renderrer
{
    class MessageAndroid : IMessage
    {
        public void LongAlert(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Long).Show();
        }

        public void ShortAlert(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Short).Show();
        }

        public void ExitApp()
        {
            CrossCurrentActivity.Current.Activity.Finish();
        }
    }
}