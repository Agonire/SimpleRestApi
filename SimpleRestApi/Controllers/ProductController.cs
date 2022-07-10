using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SimpleRestApi.Models;
using SimpleRestApi.Options;
using SimpleRestApi.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SimpleRestApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]/[action]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public ActionResult<List<Product>> GetProducts()
        {
            return Ok(_productService.GetProcucts());
        }
        [HttpPost]
        public ActionResult CreateProduct(Product product)
        {
            _productService.AddProduct(product);

            return Ok();
        }
        [HttpDelete]
        public ActionResult DeleteProduct(int productId)
        {
            var product = _productService.GetProduct(productId);

            if(product == null)
                return NotFound();

            _productService.DeleteProduct(product);

            return Ok();
        }
    }
}