using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models;

public class Race
{
    [Column("RaceId")]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Race name is a required field.")]
    [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
    public string Name { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Description is a required field.")]
    [MaxLength(500, ErrorMessage = "Maximum length for the Name is 250 characters.")]
    public string Description { get; set; } = string.Empty;
    
    [ForeignKey(nameof(Animal))]
    public int AnimalId { get; set; }
    public Animal? Animal { get; set; }
}