using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace ServerApplication.Services
{
    [DbContext(typeof(DataBaseContext))]
    public class ProductService : IProductService
    {
        private readonly DataBaseContext _Context;
        public ProductService(DataBaseContext _context)
        {
            _Context= _context;
        }
        public bool DeleteProduct(int id)
        {
            try
            {
                var product = _Context.Products.First(x => x.Id == id);
                _Context.Products.Remove(product);
                _Context.SaveChanges();
                return true;
            }
            catch (Exception msg)
            {
                return false;
            }
        }

        public Product GetProductById(int id)
        {
            return _Context.Products.First(x=>x.Id==id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _Context.Products;
        }

        public bool InsertProduct(Product product)
        {
            try
            {
                _Context.Products.Add(product);
                _Context.SaveChanges();
                return true;
            }
            catch (Exception msg)
            {
                return false;
            }
        }

        public bool UpdateProduct(Product product)
        {
            try
            {
                _Context.Products.Update(product);
                _Context.SaveChanges();
                return true;
            }
            catch (Exception msg)
            {
                return false;
            }
        }
    }
}
