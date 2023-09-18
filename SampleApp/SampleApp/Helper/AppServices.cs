using MeApp.Helper;
using Xamarin.Forms;

namespace SampleApp.Services
{
    public static class AppServices
    {
        public static void ShortAlert(string message)
        {
            DependencyService.Get<IMessage>().ShortAlert(message);
        }

        public static void LongAlert(string message)
        {
            DependencyService.Get<IMessage>().LongAlert(message);
        }

        public static void ExitApp()
        {
            DependencyService.Get<IMessage>().ExitApp();
        }
    }
}