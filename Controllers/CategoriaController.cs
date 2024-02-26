using AutoMapper;
using Dto;
using Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Models;
using Repository;

namespace Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : Controller
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IMapper _mapper;
        public CategoriaController(ICategoriaRepository categoriaRepository, IMapper mapper)
        {
             _categoriaRepository = categoriaRepository;    
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Categoria>))]
        public IActionResult GetCategorys()
        {
            var categorys = _mapper.Map<List<CategoriaDto>>(_categoriaRepository.GetCategorys());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(categorys);
        }

        [HttpGet("ById/{categoryId}")]
        [ProducesResponseType(200, Type = typeof(Categoria))]
        [ProducesResponseType(400)]
        public IActionResult GetCategory(int categoryId)
        {
            if (!_categoriaRepository.CategoryExists(categoryId))
                return NotFound();

            var category = _mapper.Map<CategoriaDto>(_categoriaRepository.GetCategory(categoryId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(category);
        }

        [HttpGet("ByTitle/{titulo}")]
        [ProducesResponseType(200, Type = typeof(Categoria))]
        [ProducesResponseType(400)]
        public IActionResult GetCategoryByTitle(string titulo)
        {
            var category = _mapper.Map<CategoriaDto>(_categoriaRepository.GetCategoryByTitle(titulo));

            if (category == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(category);

        }
    }
}
