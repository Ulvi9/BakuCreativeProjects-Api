using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BakuCreativeProjects.Data;
using BakuCreativeProjects.DTO.ChildCategory;
using BakuCreativeProjects.DTO.SubCategory;
using BakuCreativeProjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BakuCreativeProjects.Controllers
{
    public class ChildCategoryController : BaseController
    {
         private readonly IMapper _mapper;
        private DataContext _context { get; set; }
        public ChildCategoryController(IMapper mapper,DataContext context )
        {
            _mapper = mapper;
            _context = context;
        }

        /// <summary>
        /// Get All ChildCategories
        /// </summary>
        /// <returns></returns>
        // GET: api/<ChildCategoryController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChildCategoryReturnDto>>> Get()
        {
            var childCategories =await _context.ChildCategories
                .Include(c=>c.SubCategory)
                .ThenInclude(c=>c.MainCategory)
                .ToListAsync();
            var mapChildCategories = _mapper.Map<IEnumerable<ChildCategoryReturnDto>>(childCategories);
            return Ok(mapChildCategories);
        }
        /// <summary>
        /// Get ChildCategory by Id
        /// </summary>
        /// <param name="id">for ChildCategory</param>
        /// <returns></returns>
        // GET api/<ChildController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var childCategory = await _context.ChildCategories
                .FirstOrDefaultAsync(x => x.Id == id);
            if (childCategory == null) return NotFound();
            
            return Ok(childCategory);
        }
        /// <summary>
        /// Create new ChildCategory
        /// </summary>
        /// <param name="ChildCategory"></param>
        /// <returns></returns>
        // POST api/<ChildController>
        [HttpPost]
        public async Task<ActionResult<ChildCategoryCreateDto>> Post([FromBody] ChildCategoryCreateDto childCategoryCreateDto)
        {
            if (!ModelState.IsValid) return BadRequest();
            var mapChildCategory = 
                _mapper.Map<ChildCategory>(childCategoryCreateDto);
            var existChildCategory = await _context.ChildCategories
                .FirstOrDefaultAsync(c => c.Name == mapChildCategory.Name);
            if (existChildCategory != null) return Conflict(new {message="Bu childCategory artiq movcuddur"});
            await _context.ChildCategories.AddAsync(mapChildCategory);
            await _context.SaveChangesAsync();
            return Ok(childCategoryCreateDto);
        }
        /// <summary>
        /// Delete ChildCategory
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE api/<ChildCategoryController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var childCategory = await _context.ChildCategories
                .FirstOrDefaultAsync(b => b.Id == id);
            if (childCategory == null) return NotFound();
            _context.ChildCategories.Remove(childCategory);
            await _context.SaveChangesAsync();
            return Ok();
        }
        /// <summary>
        /// Update ChildCategory
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ChildCategory"></param>
        /// <returns></returns>
        // PUT api/<ChildController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ChildCategoryUpdateDto>> Update(int id, [FromBody] ChildCategoryUpdateDto childCategoryUpdateDto)
        {
            if (id != childCategoryUpdateDto.Id) return BadRequest();
            var dbChildCategory = await _context.ChildCategories
                .FirstOrDefaultAsync(c => c.Id == id);
            if (dbChildCategory == null) return NotFound();
            var mapperChildCategory = _mapper.Map<ChildCategory>(childCategoryUpdateDto);
            dbChildCategory.Name = mapperChildCategory.Name;
            dbChildCategory.SubCategoryId = mapperChildCategory.SubCategoryId;
            var existChildCategory = await _context.ChildCategories
                .FirstOrDefaultAsync(c => c.Name == dbChildCategory.Name);
            if (existChildCategory != null) return Conflict(new {message = "bu adli child category artiq movcuddur"});
            await _context.SaveChangesAsync();
            return Ok();
        }
       
    }
}