using SampleApp.Models;
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
    public partial class AddProductPage : ContentPage
    {

        internal LandingViewModel ViewModel;
        public AddProductPage(LandingViewModel ViewModel)
        {
            
            BindingContext = this.ViewModel = ViewModel;
            InitializeComponent();
        }


        async void Save_Clicked(object sender, EventArgs e)
        {
            if (dataForm.Validate())
            {
                ViewModel.AddNewProductCommand.Execute(null);
                await Navigation.PopModalAsync();
            }
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}