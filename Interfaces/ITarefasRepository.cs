using Models;

namespace Interfaces
{
    public interface ITarefasRepository
    {
        ICollection<Tarefas> GetTasks();
        Tarefas GetTask(int id);
        Tarefas GetTaskByDescription(string descricao);
        ICollection<Tarefas> GetTask(DateTime date);
        bool TaskExists(int taskId);
    }
}
