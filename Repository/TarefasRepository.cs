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
        public async Task<ICollection<Tarefas>> GetTasks()
        {
            return await _context.Tarefas.OrderBy(x => x.Id).ToListAsync();
        }

        public async Task<Tarefas> GetTask(int id)
        {
            return await _context.Tarefas.Where(t => t.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Tarefas> GetTaskByDescription(string descricao)
        {
            return await _context.Tarefas.Where(x => x.Descricao == descricao).FirstOrDefaultAsync();
        }

        public async Task<ICollection<Tarefas>> GetTask(DateTime date)
        {
            return await _context.Tarefas.Where(x => x.Data.Date == date).ToListAsync();
        }

        public bool TaskExists(int taskId)
        {
            return _context.Tarefas.Any(x => x.Id == taskId);  
        }

        public Task<int> UpdateTask()
        {
            throw new NotImplementedException();
        }
    }
}
