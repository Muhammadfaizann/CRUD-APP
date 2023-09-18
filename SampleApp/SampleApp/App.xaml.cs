using SampleApp.Services;
using SampleApp.ViewModels;
using SampleApp.Views;
using Splat;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleApp
{
    public partial class App : Application
    {
        public App()
        {
            LicenseRegisteration();
            
            InitializeComponent();

            MainPage = new AppShell();
        }
        private void LicenseRegisteration()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NTE2NzE3QDMxMzkyZTMzMmUzMElRcmhyS1hjYW1SdGpnOTlTM3Q3SmlSRmtxaWF2L1EyV1plRkJpamZGSU09");
        }
        private void InitializeViewModelsAndServices()
        {
            // Services
            Locator.CurrentMutable.RegisterLazySingleton<IProductService>(() => new ProductService());

            // ViewModels
            Locator.CurrentMutable.Register(() => new LandingViewModel());

        }
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
