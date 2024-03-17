using AutoMapper;
using Dto;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;
using Repository;

namespace Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class CategoriaRankController : Controller
    {
        private readonly ICategoriaRankRepository _categoryRankRepository;
        private readonly IMapper _mapper;
        public CategoriaRankController(ICategoriaRankRepository categoryRankRepositoty, IMapper mapper)
        {
            _categoryRankRepository = categoryRankRepositoty;
            _mapper = mapper;   
        }

        [HttpGet]
        public IActionResult GetCategorysRank()
        {
            var categorys = _categoryRankRepository.GetCategorysRank();

            if(!ModelState.IsValid)
                return BadRequest(ModelState);


            return Ok(categorys);
        }

        [HttpGet("ById/{categoryRankId}")]
        [ProducesResponseType(200, Type = typeof(CategoriaRank))]
        [ProducesResponseType(400)]
        public IActionResult GetCategoryRank(int categoryRankId)
        {
            if (!_categoryRankRepository.CategoryRankExists(categoryRankId))
                return NotFound();

            var category = _categoryRankRepository.GetCategoryRankById(categoryRankId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(category);
        }

        [HttpGet("ByTitle/{description}")]
        [ProducesResponseType(200, Type = typeof(Categoria))]
        [ProducesResponseType(400)]
        public IActionResult GetCategoryRankByDescription(string description)
        {
            var category = _categoryRankRepository.GetCategoryRankByDescription(description);

            if (category == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(category);

        }

        [HttpPost]
        [ProducesResponseType(204)]
        public IActionResult CreateCategoryRank([FromBody] CategoriaRankDto categoryRank)
        {
            if (categoryRank == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var categoryRankMap = _mapper.Map<CategoriaRank>(categoryRank); 

            if (!_categoryRankRepository.CreateCategoryRank(categoryRankMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin.");
                return StatusCode(500, ModelState);
            }

            return Ok("Sucessfully created");

        }

        [HttpPut("{categoryRankId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateCategoryRank(int categoryRankId, [FromBody] CategoriaRankDto categoryRank)
        {
            if (categoryRank == null)
                return BadRequest(ModelState);

            if (categoryRankId != categoryRank.CategoriaRankId)
                return BadRequest(ModelState);

            if (!_categoryRankRepository.CategoryRankExists(categoryRankId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var categoryRankMap = _mapper.Map<CategoriaRank>(categoryRank);

            if (!_categoryRankRepository.UpdateCategoryRank(categoryRankMap))
            {
                ModelState.AddModelError("", "Something went wrong updating category Rank");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{categoryRankId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteCategoryRank(int categoryRankId)
        {
            if (!_categoryRankRepository.CategoryRankExists(categoryRankId))
            {
                return NotFound();
            }

            var categoryRankToDelete = _categoryRankRepository.GetCategoryRankById(categoryRankId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_categoryRankRepository.DeleteCategoryRank(categoryRankToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting category rank");
            }

            return NoContent();
        }
    }
}
