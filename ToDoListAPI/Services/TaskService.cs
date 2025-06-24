using ToDoListAPI.DTOs;
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

    public TaskItem? GetById(int id)
    {
        return _tasks.FirstOrDefault(t => t.Id == id);
    }

    public CreateTaskResponse Create(CreateTaskRequest request)
    {
        var task = new TaskItem
        {
            Id = _currentId++,
            Title = request.Title,
            Description = request.Description,
            Status = request.Status,
            Priority = request.Priority
        };

        _tasks.Add(task);

        return new CreateTaskResponse
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description,
            Status = task.Status.ToString(),
            Priority = task.Priority.ToString()
        };
    }

    public bool Update(int id, UpdateTaskRequest request)
    {
        var task = _tasks.FirstOrDefault(t => t.Id == id);
        if (task == null)
            return false;

        task.Title = request.Title;
        task.Description = request.Description;
        task.Status= request.Status;
        task.Priority = request.Priority;

        return true;
    }
    public bool Delete(int id)
    {
        var task = _tasks.FirstOrDefault(t => t.Id == id);
        if (task == null)
            return false;

        _tasks.Remove(task);
        return true;
    }
}
