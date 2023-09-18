using Newtonsoft.Json;
using SampleApp.Client;
using SampleApp.Helper;
using SampleApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp.Services
{
    public class ProductService : IProductService
    {
        
        public  ObservableCollection<Product> _products = new ObservableCollection<Product>() { new Product { Id = 1, Name = "Apple", Description = "Macbook", Price = 233 }, new Product { Id = 2, Name = "Samsung", Description = "Android", Price = 665 }, new Product { Id = 3, Name = "Dell", Description = "Laptop", Price = 444 } };
        public async Task<bool> CreateProduct(CreateProduct product)
        {
            try
            {
                var client = new RestClient();
                string response = await client.PostAsync("api/Product/AddProduct",product);
                if (response.Equals("true"))
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteProduct(Product product)
        {
            try
            {
                var client = new RestClient();
                string response = await client.DeleteAsync("api/Product/DeleteProduct/"+product.Id);
                _products.Remove(product);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<Product>> RetriveProducts()
        {
            var client = new RestClient();
            List<Product> response = await client.GetAsync<List<Product>>("api/Product/GetProducts");
            if (response!=null)
            {
                try
                {
                    
                    return response;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            var client = new RestClient();
            string response = await client.PutAsync("api/Product/UpdateProduct", product);
            var obj = _products.Where(x => x.Id == product.Id).FirstOrDefault();
            _products.Remove(obj);
            _products.Add(product);
            return true;
        }
    }
}
