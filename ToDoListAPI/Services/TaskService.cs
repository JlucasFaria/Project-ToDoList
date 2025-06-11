using ToDoListAPI.Models;

namespace ToDoListAPI.Services;

public class TaskService : ITaskService
{
    private readonly List<TaskItem> _tasks = new();
    private int _currentId = 0;


    public List<TaskItem> GetAll()
    {
        return _tasks;
    }

    public void Create(TaskItem item)
    {
        item.Id = _currentId++;
        _tasks.Add(item);
    }

}
