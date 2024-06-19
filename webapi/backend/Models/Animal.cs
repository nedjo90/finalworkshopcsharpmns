using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models;

public class Animal
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    
}