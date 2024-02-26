using Data;
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

    }
}
