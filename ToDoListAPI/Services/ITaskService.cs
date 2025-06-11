using ToDoListAPI.Models;

namespace ToDoListAPI.Services;

public interface ITaskService
{
    List<TaskItem> GetAll();
    void Create(TaskItem item);
}
