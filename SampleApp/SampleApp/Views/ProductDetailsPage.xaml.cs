using SampleApp.Services;
using SampleApp.ViewModels;
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
    public partial class ProductDetailsPage : ContentPage
    {
        internal LandingViewModel ViewModel;
        private readonly IProductService productService;
        public ProductDetailsPage(LandingViewModel viewModel)
        {
            BindingContext = ViewModel = viewModel;
            productService=new ProductService();
            InitializeComponent();
        }

        private async void Delete_ClickedAsync(object sender, EventArgs e)
        {
            ViewModel.DeleteProduct();
            AppServices.ShortAlert("Product deleted successfully!");
            await Navigation.PopModalAsync();
        }

        private async void Edit_ClickedAsync(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new UpdateProductPage(ViewModel)));
        }
    }
}