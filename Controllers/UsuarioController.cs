using AutoMapper;
using Dto;
using Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Models;
using Repository;
using System.Runtime.CompilerServices;

namespace Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        public UsuarioController(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Usuario>))]
        public IActionResult GetUsers()
        {
            var users = _mapper.Map<List<UsuarioDto>>(_usuarioRepository.GetUsers());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(users);
        }

        [HttpGet("ById/{usuarioId}")]
        [ProducesResponseType(200, Type = typeof(Usuario))]
        [ProducesResponseType(400)]
        public IActionResult GetUser(int usuarioId)
        {
            if (!_usuarioRepository.UserExists(usuarioId))
                return NotFound();

            var user = _mapper.Map<UsuarioDto>(_usuarioRepository.GetUser(usuarioId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(user);
        }

        [HttpGet("ByName/{nome}")]
        [ProducesResponseType(200, Type = typeof(Usuario))]
        [ProducesResponseType(400)]
        public IActionResult GetUserByName(string nome)
        {
            var task = _mapper.Map<List<UsuarioDto>>(_usuarioRepository.GetUserByName(nome));

            if (task == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(task);

        }

        [HttpPost]
        [ProducesResponseType(204)]
        public IActionResult CreateUser([FromBody] Usuario user)
        {
            if (user == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userMap = _mapper.Map<Usuario>(user);

            if (!_usuarioRepository.CreateUser(user))
            {
                ModelState.AddModelError("", "Something went wrong while savin.");
                return StatusCode(500, ModelState);
            }

            return Ok("Sucessfully created");
        }

        [HttpPut("{userId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateUser(int userId, [FromBody] Usuario user)
        {
            if (user == null)
                return BadRequest(ModelState);

            if (userId != user.Id)
                return BadRequest(ModelState);

            if (!_usuarioRepository.UserExists(userId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            //var userMap = _mapper.Map<Usuario>(user);

            if (!_usuarioRepository.UpdateUser(user))
            {
                ModelState.AddModelError("", "Something went wrong updating user");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{userId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteUser(int userId)
        {
            if(!_usuarioRepository.UserExists(userId))
            {
                return NotFound();
            }

            var userToDelete = _usuarioRepository.GetUser(userId);

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_usuarioRepository.DeleteUser(userToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting user");
            }

            return NoContent();
        }
    }
}
