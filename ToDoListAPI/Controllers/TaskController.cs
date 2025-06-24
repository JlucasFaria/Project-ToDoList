using Microsoft.AspNetCore.Mvc;
using ToDoListAPI.DTOs;
using ToDoListAPI.Models;
using ToDoListAPI.Services;

namespace ToDoListAPI.Controllers;

[ApiController]
[Route("api[controller]")]
public class TaskController : ControllerBase
{
    private readonly ITaskService _taskService;

    public TaskController(ITaskService taskService)
    {
        _taskService = taskService;
    }


    [HttpPost]
    public IActionResult Create([FromBody] CreateTaskRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var task = new TaskItem
        {
            Title = request.Title,
            Description = request.Description,
            Status = request.Status,
            Priority = request.Priority,
        };

        var response = _taskService.Create(request);
        return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var task = _taskService.GetAll();
        return Ok(task);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var task = _taskService.GetById(id);
        if (task == null)
        {
            return NotFound();
        }

        var response = new CreateTaskResponse
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description,
            Status = task.Status.ToString(),
            Priority = task.Priority.ToString()
        };

        return Ok(response);
    }

    [HttpPut] 
    public IActionResult Update(int id, [FromBody] UpdateTaskRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var update = _taskService.Update(id, request);
        if (!update)
            return NotFound();

        return NoContent();
    }
    [HttpDelete]
    public IActionResult Delete(int id)
    {
        var deleted = _taskService.Delete(id);
        if (!deleted)
            return NotFound();

        return NoContent();
    }

}
