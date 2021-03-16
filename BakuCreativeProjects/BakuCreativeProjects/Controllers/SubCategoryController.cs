using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BakuCreativeProjects.Data;
using BakuCreativeProjects.DTO;
using BakuCreativeProjects.DTO.SubCategory;
using BakuCreativeProjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BakuCreativeProjects.Controllers
{
    public class SubCategoryController : BaseController
    {
        private readonly IMapper _mapper;
        private DataContext _context { get; set; }
        public SubCategoryController(IMapper mapper,DataContext context )
        {
            _mapper = mapper;
            _context = context;
        }

        /// <summary>
        /// Get All SubCategories
        /// </summary>
        /// <returns></returns>
        // GET: api/<SubCategoryController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubCategoryReturnDto>>> Get()
        {
            var subCategories =await _context.SubCategories
                .Include(c => c.ChildCategories).ToListAsync();
            var mapSubCategories = 
                _mapper.Map<IEnumerable<SubCategory>, IEnumerable<SubCategoryReturnDto>>(subCategories);
            return Ok(mapSubCategories);
        }
        /// <summary>
        /// Get SubCategory by Id
        /// </summary>
        /// <param name="id">for SubCategory</param>
        /// <returns></returns>
        // GET api/<SubController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var subCategory = await _context.SubCategories
                .Include(c => c.ChildCategories)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (subCategory == null) return NotFound();
            var mapSubCategory = _mapper.Map<SubCategoryReturnDto>(subCategory);
            
            return Ok(mapSubCategory);
        }
        /// <summary>
        /// Create new SubCategory
        /// </summary>
        /// <param name="SubCategory"></param>
        /// <returns></returns>
        // POST api/<SubController>
        [HttpPost]
        public async Task<ActionResult<SubCategoryCreateDto>> Post([FromBody] SubCategoryCreateDto subCategoryCreateDto)
        {
            if (!ModelState.IsValid) return BadRequest();
            var mapSubCategories = 
                _mapper.Map<SubCategory>(subCategoryCreateDto);
            var existSubCategory = await _context.MainCategories
                .FirstOrDefaultAsync(c => c.Name == mapSubCategories.Name);
            if (existSubCategory != null) return Conflict(new {message="Bu subCategory artiq movcuddur"});
            await _context.SubCategories.AddAsync(mapSubCategories);
            await _context.SaveChangesAsync();
            return Ok(subCategoryCreateDto);
        }
        /// <summary>
        /// Delete SubCategory
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE api/<SubCategoryController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var subCategory = await _context.SubCategories
                .FirstOrDefaultAsync(b => b.Id == id);
            if (subCategory == null) return NotFound();
            _context.SubCategories.Remove(subCategory);
            await _context.SaveChangesAsync();
            return Ok();
        }
        /// <summary>
        /// Update SubCategory
        /// </summary>
        /// <param name="id"></param>
        /// <param name="SubCategory"></param>
        /// <returns></returns>
        // PUT api/<SubController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<SubCategoryUpdateDto>> Update(int id, [FromBody] SubCategoryUpdateDto subCategoryUpdateDto)
        {
            if (id != subCategoryUpdateDto.Id) return BadRequest();
            var dbSubCategory = await _context.SubCategories
                .FirstOrDefaultAsync(c => c.Id == id);
            if (dbSubCategory == null) return NotFound();
            var mapperSubCategory = _mapper.Map<SubCategory>(subCategoryUpdateDto);
            dbSubCategory.Name = mapperSubCategory.Name;
            dbSubCategory.MainCategoryId = mapperSubCategory.MainCategoryId;
            var existSubCategory = await _context.SubCategories
                .FirstOrDefaultAsync(c => c.Name == dbSubCategory.Name);
            if (existSubCategory != null) return Conflict(new {message = "bu adli sub category artiq movcuddur"});
            await _context.SaveChangesAsync();
            return Ok();
        }
        
    }
}