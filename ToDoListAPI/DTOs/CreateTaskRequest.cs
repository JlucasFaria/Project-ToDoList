using System.ComponentModel.DataAnnotations;
using ToDoListAPI.Models;

namespace ToDoListAPI.DTOs;

public class CreateTaskRequest
{
    [Required]
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty ;
    public StatusTask Status { get; set; }
}
