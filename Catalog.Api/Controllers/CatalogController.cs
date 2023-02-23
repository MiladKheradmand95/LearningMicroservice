using Catalog.Api.Entites;
using Catalog.Api.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {

        #region Constructor
        private readonly IProductRepository _productRepository;
        private readonly ILogger<CatalogController> _logger;
        public CatalogController(IProductRepository productRepository, ILogger<CatalogController> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }
        #endregion

        [HttpGet("getAllProducts")]
        public async Task<IActionResult> GatAllProducts()
        {
            try
            {
                return Ok(await _productRepository.GetAllProducts());
            }
            catch (Exception e)
            {
              _logger.LogError(e.Message, e);
                return BadRequest();
            }
        }

        [HttpGet("getProductByName")]
        public async Task<IActionResult> GetProductByName(string name)
        {
            try
            {
                var product = await _productRepository.GetProductByName(name);
                if (product == null)
                {
                    return NotFound();
                }
                return Ok(product);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
               return BadRequest(e.Message);
            }
        }

        [HttpGet("getProductById")]
        public async Task<IActionResult> GetProductById(string id)
        {
            try
            {
                var product = await _productRepository.GetProductById(id);

                if (product==null)
                {
                    return NotFound(id);
                }

                return Ok(product);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return BadRequest(e.Message);
            }
        }

        [HttpGet("getProductByCategory")]
        public async Task<IActionResult> GetProductByCatagory(string catagory)
        {
            try
            {
                var product = await _productRepository.GetProductByCatagory(catagory);
                if (product==null)
                {
                    return NotFound();
                }
                return Ok(product);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return BadRequest(e.Message);
            }
        }

        [HttpPost("createProduct")]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            try
            {
                await _productRepository.CreateProduct(product);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message,e);
                return BadRequest(e.Message);    
            }
        }

        [HttpPut("updateProduct")]
        public async Task<IActionResult> UpdateProduct(Product product)
        {
            try
            {
                if (product==null)
                {
                    return BadRequest("Product not found");
                }
                 var result=await _productRepository.UpdateProduct(product);
                if (result)
                {
                    return Ok();
                }
                return BadRequest(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message,e);
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("deleteProduct")]

        public async Task<IActionResult> DeleteProduct(string id)
        {
            try
            {
              var result= await _productRepository.DeleteProduct(id);
                if (result)
                {
                    return Ok();
                }
                return BadRequest(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message,e);
                return BadRequest(e.Message);
            }
        }
    }
}
