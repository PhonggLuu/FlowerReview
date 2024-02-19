using AutoMapper;
using FlowerReviewApp.Dto;
using FlowerReviewApp.Interfaces;
using FlowerReviewApp.Models;
using FlowerReviewApp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FlowerReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController :ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductController(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Product>))]
        public IActionResult GetProducts()
        {
            var products = _mapper.Map<List<ProductDto>>(_productRepository.GetProducts());
            return Ok(products);
        }

        [HttpGet("{productId}")]
        [ProducesResponseType(200, Type = typeof(Product))]
        [ProducesResponseType(400)]
        public IActionResult GetProduct(int productId)
        {
            if(!_productRepository.IsProductExists(productId))
                return NotFound();
            var product = _mapper.Map<ProductDto>(_productRepository.GetProductById(productId));
            return Ok(product);
        }

        [HttpGet("flower/{productId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<DetailedProduct>))]
        [ProducesResponseType(400)]
        public IActionResult GetFlowerByProduct(int productId)
        {
            if(!_productRepository.IsProductExists(productId))
                return NotFound();
            var flowers = _mapper.Map<List<FlowerDto>>(_productRepository.GetFlowerByProduct(productId));
            return Ok(flowers);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateProduct([FromBody] ProductDto productCreate)
        {
            if (productCreate == null)
                return BadRequest(ModelState);
            var product = _productRepository.GetProducts()
                .Where(f => f.ProductName.ToUpper() == productCreate.ProductName.Trim().ToUpper())
                .FirstOrDefault();
            if (product != null)
            {
                ModelState.AddModelError("", "Product already exists");
                return StatusCode(422, ModelState);
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var productMap = _mapper.Map<Product>(productCreate);
            productMap.ProductName = productCreate.ProductName.Trim();
            productMap.CreatedAt = DateTime.UtcNow;
            productMap.UpdatedAt = DateTime.UtcNow;
            if (!_productRepository.CreateNewProduct(productMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving!");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully created");
        }

        [HttpPut("{productId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateProduct(int productId, [FromBody] ProductDto updatedProduct)
        {
            if (updatedProduct == null)
                return BadRequest(ModelState);

            if (productId != updatedProduct.ProductId)
                return BadRequest(ModelState);

            if (!_productRepository.IsProductExists(productId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var productMap = _mapper.Map<Product>(updatedProduct);

            if (!_productRepository.UpdateProduct(productMap))
            {
                ModelState.AddModelError("", "Something went wrong updating product");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{productId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteProduct(int productId)
        {
            if (!_productRepository.IsProductExists(productId))
            {
                return NotFound();
            }

            if (_productRepository.IsReference(productId))
            {
                ModelState.AddModelError("", "Product is referenced. Cannot delete");
                return BadRequest(ModelState);
            }

            var productToDelete = _productRepository.GetProductById(productId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_productRepository.DeleteProduct(productToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting product");
            }

            return NoContent();
        }
    }
}
