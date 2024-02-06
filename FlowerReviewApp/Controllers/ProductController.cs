using AutoMapper;
using FlowerReviewApp.Dto;
using FlowerReviewApp.Interfaces;
using FlowerReviewApp.Models;
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
    }
}
