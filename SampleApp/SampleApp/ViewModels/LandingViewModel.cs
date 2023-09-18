using SampleApp.Models;
using SampleApp.Services;
using SampleApp.ViewModel;
using SampleApp.Views;
using Splat;
using Syncfusion.DataSource.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SampleApp.ViewModels
{
    public class LandingViewModel : BaseViewModel
    {
        #region private Properties
        private readonly IProductService productService;
        private List<Product> _products = new List<Product>() { new Product { Id = 1, Name = "Apple", Description = "Macbook", Price = 233 }, new Product { Id = 2, Name = "Samsung", Description = "Android", Price = 665 }, new Product { Id = 3, Name = "Dell", Description = "Laptop", Price = 444 } };
        private CreateProduct newProduct;
        private Product _SelectedProduct;
        private bool _IsEmptyViewVisible;
        private bool _IsUpdateServicePopVisible;
        #endregion

        #region Commands
        public ICommand AddNewProductCommand => new Command(() => AddNewProduct());

        #endregion

        #region Public Properties
        public CreateProduct NewProduct
        {
            get
            {
                return newProduct;
            }
            set
            {
                SetProperty(ref newProduct, value);
            }
        }
        public Product SelectedProduct
        {
            get
            {
                return _SelectedProduct;
            }
            set
            {
                SetProperty(ref _SelectedProduct, value);
            }
        }
        public ObservableCollection<Product> ProductList { set; get; }
        public bool IsEmptyViewVisible
        {
            get
            {
                return _IsEmptyViewVisible;
            }
            set
            {
                SetProperty(ref _IsEmptyViewVisible, value);
            }
        }
        public bool IsUpdateServicePopVisible
        {
            get
            {
                return _IsUpdateServicePopVisible;
            }
            set
            {
                SetProperty(ref _IsUpdateServicePopVisible, value);
            }
        }
        #endregion

        #region ViewModel
        public LandingViewModel()
        {
            try
            {
                productService=new ProductService();
                ProductList = new ObservableCollection<Product>();
                newProduct = new CreateProduct();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
        #endregion

        #region Private Methods
        private async void AddNewProduct()
        {
            try
            {
                var response=await productService.CreateProduct(newProduct);
                AppServices.ShortAlert("Product added successfully!");
                newProduct = new CreateProduct();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
        internal async void DeleteProduct()
        {
            try
            {
                var response = await productService.DeleteProduct(SelectedProduct);
                _products.Remove(SelectedProduct);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
        internal void OnAppearing()
        {
            ExecuteLoadProductsAsync();
        }
        async Task ExecuteLoadProductsAsync()
        {

            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                if (_products != null && _products.Count != 0)
                {
                    IsEmptyViewVisible = false;
                    ProductList.Clear();
                    _products= await productService.RetriveProducts();
                    foreach (var product in _products)
                      ProductList.Add(product);
                }
                else
                {
                    IsEmptyViewVisible = true;
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
        #endregion

    }
}
