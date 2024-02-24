using Models;

namespace Interfaces
{
    public interface ITarefasRepository
    {
        Task<ICollection<Tarefas>> GetTasks();
        Task<Tarefas> GetTask(int id);
        Task<Tarefas> GetTaskByDescription(string descricao);
        Task<ICollection<Tarefas>> GetTask(DateTime date);
        bool TaskExists(int taskId);
        Task<int> UpdateTask();
    }
}
