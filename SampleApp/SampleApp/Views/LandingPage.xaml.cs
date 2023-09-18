using SampleApp.ViewModels;
using Splat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LandingPage : ContentPage
    {
        internal LandingViewModel ViewModel { get; set; } = new LandingViewModel();
        public LandingPage()
        {
            BindingContext = ViewModel;
            InitializeComponent();
            
        }
        
        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new AddProductPage(ViewModel)));
        }
        protected override void OnAppearing()
        {
            if (ViewModel != null)
            {
                base.OnAppearing();
                ViewModel.OnAppearing();
            }
        }

        private async void listView_SelectionChangedAsync(object sender, Syncfusion.ListView.XForms.ItemSelectionChangedEventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new ProductDetailsPage(ViewModel)));
        }

        private async void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new ProductDetailsPage(ViewModel)));
        }
    }
}