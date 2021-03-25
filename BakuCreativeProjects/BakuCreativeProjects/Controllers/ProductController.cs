using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BakuCreativeProjects.DTO;
using BakuCreativeProjects.DTO.Product;
using BakuCreativeProjects.Models;
using BakuCreativeProjects.Repo;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace BakuCreativeProjects.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IMapper _mapper;
        private IWebHostEnvironment _env;
        private readonly IProductRepository _productRepository;
        public ProductController(IMapper mapper,
            IWebHostEnvironment env,
            IProductRepository productRepository)
        {
            _mapper = mapper;
            _env = env;
            _productRepository = productRepository;
        }

        /// <summary>
        /// Get All Products
        /// </summary>
        /// <returns></returns>
        // GET: api/<ProductController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var products = await _productRepository.GetProductAsync();
            var mapperProductReturnDto = _mapper.Map<IEnumerable<ProductReturnDto>>(products);
            
            return Ok(mapperProductReturnDto);
        }

        /// <summary>
        /// Get Product from Id
        /// </summary>
        /// <param name="id">for Product</param>
        /// <returns></returns>
        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Product product = await _productRepository.GetProductByIdAsync(id);
            if (product == null) return NotFound();
            var mapperProduct = _mapper.Map<ProductReturnDto>(product);
            
            return Ok(mapperProduct);
        }
        /// <summary>
        /// Create new Product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        // POST api/<DepartmentController>
        [HttpPost]
        public async Task<ActionResult<ProductReturnDto>> Create([FromBody] ProductCreateDto productCreateDto)
        {
            var mapperProduct = _mapper.Map<Product>(productCreateDto);
            await _productRepository.CreateProductAsync(mapperProduct);
            return Ok(mapperProduct);
        }
        /// <summary>
        /// Update Product
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Product"></param>
        /// <returns></returns>
        // PUT api/<DepartmentController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> Update(int id, [FromBody] ProductUpdateDto productUpdateDto)
        {
            if (id != productUpdateDto.Id) return BadRequest();
            var mapperProduct = _mapper.Map<Product>(productUpdateDto);
            var product= await _productRepository.UpdateProductAsync(mapperProduct);
            if (product == null) return BadRequest();
           
            return Ok(product);
        }
        /// <summary>
        /// Delete Product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            Product product = await _productRepository.DeleteProductAsync(id);
            if (product == null) return NotFound();
            return Ok();
        }
    }
}