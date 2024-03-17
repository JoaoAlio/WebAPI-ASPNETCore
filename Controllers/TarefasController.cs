using AutoMapper;
using Dto;
using Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Models;
using Repository;

namespace Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class TarefasController : Controller
    {
        private readonly ITarefasRepository _tarefasRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IMapper _mapper;
        public TarefasController(ITarefasRepository taskRepository, IMapper mapper, IUsuarioRepository usuarioRepository, ICategoriaRepository categoriaRepository)
        {
            _tarefasRepository = taskRepository;
            _usuarioRepository = usuarioRepository;
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Tarefas>))]
        public IActionResult GetTasks()
        {
            var tasks = _mapper.Map<List<TarefasDto>>(_tarefasRepository.GetTasks());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(tasks);
        }

        [HttpGet("GetTask/{id}")]
        [ProducesResponseType(200, Type = typeof(Tarefas))]
        [ProducesResponseType(400)]
        public  IActionResult GetTask(int id)
        {
            if (!_tarefasRepository.TaskExists(id))
                return NotFound();

            var task = _mapper.Map<TarefasDto>( _tarefasRepository.GetTask(id));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(task);
        }

        [HttpGet("GetTaskByDescription/{descricao}")]
        [ProducesResponseType(200, Type = typeof(Tarefas))]
        [ProducesResponseType(400)]
        public IActionResult GetTaskByDescription(string descricao)
        {
            var task = _mapper.Map<TarefasDto>(_tarefasRepository.GetTaskByDescription(descricao));

            if (task == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(task);

        }

        [HttpGet("GetTaskByDate/{date}")]
        [ProducesResponseType(200, Type = typeof(Tarefas))]
        [ProducesResponseType(400)]
        public IActionResult GetTasksByDate(DateTime date)
        {
            var task = _mapper.Map<List<TarefasDto>>(_tarefasRepository.GetTasksByDate(date));

            if(task == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            return Ok(task);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        public IActionResult CreateTask([FromBody] TarefasDto task, [FromQuery] int userId, [FromQuery] int categoryId)
        {
            if (task == null)
                return BadRequest(ModelState);

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var taskMap = _mapper.Map<Tarefas>(task);

            if(!_tarefasRepository.CreateTask(taskMap, userId, categoryId))
            {
                ModelState.AddModelError("", "Something went wrong while savin.");
                return StatusCode(500, ModelState);
            }

            return Ok("Sucessfully created");
        }


        [HttpPut("{taskId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateTask(int taskId, [FromQuery] int userId, [FromQuery] int categoryId, [FromBody] TarefasDto task)
        {
            if (task == null)
                return BadRequest(ModelState);

            if (taskId != task.Id)
                return BadRequest(ModelState);

            if (!_tarefasRepository.TaskExists(taskId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var taskMap = _mapper.Map<Tarefas>(task);

            if (!_tarefasRepository.UpdateTask(taskMap, userId, categoryId))
            {
                ModelState.AddModelError("", "Something went wrong updating task");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{taskId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteTask(int taskId)
        {
            if (!_tarefasRepository.TaskExists(taskId))
            {
                return NotFound();
            }

            var taskToDelete = _tarefasRepository.GetTask(taskId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_tarefasRepository.DeleteTask(taskToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting task");
            }

            return NoContent();
        }

    }
}
