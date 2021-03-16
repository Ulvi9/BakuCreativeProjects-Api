using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BakuCreativeProjects.Data;
using BakuCreativeProjects.DTO;
using BakuCreativeProjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BakuCreativeProjects.Controllers
{
    public class MainCategoryController : BaseController
    {
        private readonly IMapper _mapper;
        private DataContext _context { get; set; }
        public MainCategoryController(IMapper mapper,DataContext context )
        {
            _mapper = mapper;
            _context = context;
        }

        /// <summary>
        /// Get All MainCategories
        /// </summary>
        /// <returns></returns>
        // GET: api/<MainCategoryController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MainCategoryReturnDto>>> Get()
        {
             var mainCategories =await _context.MainCategories
                .Include(c => c.SubCategories)
                .ThenInclude(c => c.ChildCategories).ToListAsync();
             var mapMainCategories = 
                _mapper.Map<IEnumerable<MainCategory>, IEnumerable<MainCategoryReturnDto>>(mainCategories);
            return Ok(mapMainCategories);
        }
        /// <summary>
        /// Get MainCategory by Id
        /// </summary>
        /// <param name="id">for MainCategory</param>
        /// <returns></returns>
        // GET api/<MainController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var mainCategory = await _context.MainCategories
                .Include(c => c.SubCategories)
                .ThenInclude(c => c.ChildCategories)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (mainCategory == null) return NotFound();
            var mapMainCategory = _mapper.Map<MainCategoryReturnDto>(mainCategory);
            
            return Ok(mapMainCategory);
        }
        
        /// <summary>
        /// Create new MainCategory
        /// </summary>
        /// <param name="MainCategory"></param>
        /// <returns></returns>
        // POST api/<MainController>
        [HttpPost]
        public async Task<ActionResult<MainCategoryCreateDto>> Post([FromBody] MainCategoryCreateDto mainCategoryCreateDto)
        {
            if (!ModelState.IsValid) return BadRequest();
            var mapMainCategories = 
                _mapper.Map<MainCategory>(mainCategoryCreateDto);
            var existMainCategory = await _context.MainCategories
                .FirstOrDefaultAsync(c => c.Name == mapMainCategories.Name);
            if (existMainCategory != null) return Conflict(new {message="Bu main category artiq movcuddur"});
            await _context.MainCategories.AddAsync(mapMainCategories);
            await _context.SaveChangesAsync();
            return Ok(mainCategoryCreateDto);
        }
        
        /// <summary>
        /// Delete MainCategory
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE api/<MainCategoryController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var mainCategory = await _context.MainCategories
                .FirstOrDefaultAsync(b => b.Id == id);
            if (mainCategory == null) return NotFound();
            _context.MainCategories.Remove(mainCategory);
            await _context.SaveChangesAsync();
            return Ok();
        }
        /// <summary>
        /// Update MainCategory
        /// </summary>
        /// <param name="id"></param>
        /// <param name="MainCategory"></param>
        /// <returns></returns>
        // PUT api/<MainController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<MainCategoryUpdateDto>> Update(int id, [FromBody] MainCategoryUpdateDto mainCategoryUpdateDto)
        {
            if (id != mainCategoryUpdateDto.Id) return BadRequest();
            var dbMainCategory = await _context.MainCategories
                .FirstOrDefaultAsync(c => c.Id == id);
            if (dbMainCategory == null) return NotFound();
            var mapperMainCategory = _mapper.Map<MainCategory>(mainCategoryUpdateDto);
            dbMainCategory.Name = mapperMainCategory.Name;
            var existMainCategory = await _context.MainCategories
                .FirstOrDefaultAsync(c => c.Name == dbMainCategory.Name);
            if (existMainCategory != null) return Conflict(new {message = "bu adli main category artiq movcuddur"});
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}