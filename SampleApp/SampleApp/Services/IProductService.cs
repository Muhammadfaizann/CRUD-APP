using SampleApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp.Services
{
    public interface IProductService
    {
        Task<bool> CreateProduct(CreateProduct product);
        Task<List<Product>> RetriveProducts();
        Task<bool> UpdateProduct(Product product);
        Task<bool> DeleteProduct(Product product);

    }
}
