using SampleApp.Services;
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
    public partial class UpdateProductPage : ContentPage
    {
        internal LandingViewModel ViewModel;
        private readonly IProductService productService;
        public UpdateProductPage(LandingViewModel viewModel)
        {
            BindingContext = ViewModel = viewModel;
            productService = new ProductService();
            InitializeComponent();
        }

        private async void ToolbarItem_ClickedAsync(object sender, EventArgs e)
        {
            await productService.UpdateProduct(ViewModel.SelectedProduct);
            await Shell.Current.GoToAsync("//main");
        }
    }
}