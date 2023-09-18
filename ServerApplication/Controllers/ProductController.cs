using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NWebsec.AspNetCore.Core.Web;
using ServerApplication.Mapper;
using ServerApplication.Models;
using ServerApplication.Services;

namespace ServerApplication.Controllers
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly IMapper autoMapper;

        public ProductController(DataBaseContext context, IMapper AutoMapper)
        {
                productService = new ProductService(context);
                autoMapper = AutoMapper;
        }

        [HttpGet]
        [Route("api/Product/GetProducts")]
        public IEnumerable<GetProductsDto> GetProducts()
        {
            //var context = Request.Properties["MS_HttpContext"] as HttpContextWrapper;
            //var authToken = context.Request.Headers.Get("Authorization");
            return autoMapper.Map<List<GetProductsDto>>(productService.GetProducts());
        }

        [HttpGet]
        [Route("api/Product/GetProduct/{id}")]
        public ProductDto GetProduct(int id)
        {
            return autoMapper.Map<ProductDto>(productService.GetProductById(id));
        }

        [HttpPost]
        [Route("api/Product/AddProduct")]
        public IActionResult AddProduct(ProductDto productdto)
        {
            Product product = autoMapper.Map<Product>(productdto);
            var isInserted= productService.InsertProduct(product);
            if (isInserted)
                return Ok();
            else
                return StatusCode(500);
        }

        [HttpDelete]
        [Route("api/Product/DeleteProduct/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var isDeleted=productService.DeleteProduct(id);
            if (isDeleted)
                return Ok();
            else
                return StatusCode(500);

        }

        [HttpPut]
        [Route("api/Product/UpdateProduct")]
        public IActionResult UpdateProduct(UpdateProductDto productdto)
        {
            Product product = autoMapper.Map<Product>(productdto);
            var isUpdated=productService.UpdateProduct(product);
            if (isUpdated)
                return Ok();
            else
                return StatusCode(500);
        }

    }
}