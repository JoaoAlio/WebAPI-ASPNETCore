using AutoMapper;
using Dto;
using Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Models;

namespace Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class TarefasController : Controller
    {
        private readonly ITarefasRepository _tarefasRepository;
        private readonly IMapper _mapper;
        public TarefasController(ITarefasRepository taskRepository, IMapper mapper)
        {
            _tarefasRepository = taskRepository;
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
            var tarefa = _mapper.Map<TarefasDto>(_tarefasRepository.GetTaskByDescription(descricao));

            if (tarefa == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(tarefa);

        }
        
    }
}
