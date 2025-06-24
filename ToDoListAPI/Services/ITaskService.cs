using ToDoListAPI.DTOs;
using ToDoListAPI.Models;

namespace ToDoListAPI.Services;

public interface ITaskService
{
    List<TaskItem> GetAll();
    TaskItem? GetById(int id);
    CreateTaskResponse Create(CreateTaskRequest request);
    bool Update(int id, UpdateTaskRequest request);
    bool Delete(int id);
}
