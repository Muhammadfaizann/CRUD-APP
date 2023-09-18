using SampleApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SampleApp.Helper
{
    public static class Utils
    {
        public static ObservableCollection<Product> _products = new ObservableCollection<Product>() { new Product { Id = 1, Name = "Apple", Description = "Macbook", Price = 233 }, new Product { Id = 2, Name = "Samsung", Description = "Android", Price = 665 }, new Product { Id = 3, Name = "Dell", Description = "Laptop", Price = 444 } };
    }
}
