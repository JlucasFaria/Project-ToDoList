using System.ComponentModel.DataAnnotations;
using ToDoListAPI.Models;

namespace ToDoListAPI.DTOs;

public class CreateTaskRequest
{
    [Required(ErrorMessage = "The title is required.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "The title must be between 3 and 100 characters.")]
    public string Title { get; set; } = string.Empty;

    [StringLength(500, ErrorMessage = "The description must be up to 500 characters.")]
    public string Description { get; set; } = string.Empty;

    [Required(ErrorMessage = "The status is required.")]
    [EnumDataType(typeof(StatusTask), ErrorMessage = "Invalid status value.")]
    public StatusTask Status { get; set; }

    [Required(ErrorMessage = "The priority is required.")]
    [EnumDataType(typeof(TaskPriority), ErrorMessage = "Invalid priority value.")]
    public TaskPriority Priority { get; set; }
}
