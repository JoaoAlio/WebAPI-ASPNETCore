using Data;
using Dto;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Runtime.CompilerServices;

namespace Repository
{
    public class TarefasRepository : ITarefasRepository
    {
        private readonly DataContext _context;

        public TarefasRepository(DataContext context)
        {
            _context = context; 
        }
        public ICollection<Tarefas> GetTasks()
        {
            return  _context.Tarefas.OrderBy(x => x.Id).ToList();
        }

        public Tarefas GetTask(int id)
        {
            return  _context.Tarefas.Where(t => t.Id == id).FirstOrDefault();
        }

        public Tarefas GetTaskByDescription(string descricao)
        {
            return  _context.Tarefas.Where(x => x.Descricao == descricao).FirstOrDefault();
        }

        public ICollection<Tarefas> GetTasksByDate(DateTime date)
        {
            return _context.Tarefas.Where(x => x.Data.Date == date).ToList();
        }

        public bool TaskExists(int taskId)
        {
            return _context.Tarefas.Any(x => x.Id == taskId);  
        }

        public bool CreateTask(Tarefas task, int userId, int categoryId)
        {
            var taskUserEntity = _context.Usuarios.Where(u => u.Id == userId).FirstOrDefault();
            var taskCategoryEntity = _context.Categorias.Where(c => c.Id == categoryId).FirstOrDefault();

            var tarefa = new Tarefas()
            {
                Descricao = task.Descricao,
                Data = task.Data,
                Categoria = taskCategoryEntity,
                Usuario = taskUserEntity
            };

            _context.Add(tarefa);

            return Save();

        }

        public bool UpdateTask(Tarefas task, int userId, int categoryId)
        {
            task.UsuarioId = userId;
            task.CategoriaId = categoryId;
            _context.Update(task);
            return Save();
        }

        public bool DeleteTask(Tarefas task) 
        {
            _context.Remove(task);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
