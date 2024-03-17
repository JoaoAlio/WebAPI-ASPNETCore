using Dto;
using Models;

namespace Interfaces
{
    public interface ITarefasRepository
    {
        ICollection<Tarefas> GetTasks();
        Tarefas GetTask(int id);
        Tarefas GetTaskByDescription(string descricao);
        ICollection<Tarefas> GetTasksByDate(DateTime date);
        bool TaskExists(int taskId);
        bool CreateTask(Tarefas task, int userId, int categoryId);
        bool UpdateTask(Tarefas task, int userId, int categoryId);
        bool DeleteTask(Tarefas task);    
        bool Save();
    }
}
