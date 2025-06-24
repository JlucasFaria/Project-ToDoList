using System.ComponentModel.DataAnnotations;
using ToDoListAPI.Models;

namespace ToDoListAPI.DTOs;

public class UpdateTaskRequest
{
    [Required(ErrorMessage = "The title is required.")]
    [StringLength(100, MinimumLength = 3)]
    public string Title { get; set; } = string.Empty;

    [StringLength(500)]
    public string Description { get; set; } = string.Empty;

    [Required]
    [EnumDataType(typeof(StatusTask))]
    public StatusTask Status { get; set; }

    [Required]
    [EnumDataType(typeof(TaskPriority))]
    public TaskPriority Priority { get; set; }
}
