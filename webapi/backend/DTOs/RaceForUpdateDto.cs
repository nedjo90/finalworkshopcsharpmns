using System.ComponentModel.DataAnnotations;

namespace backend.DTOs;

public record RaceForUpdateDto
{
    [Required(ErrorMessage = "Race name is a required field.")]
    [MinLength(2, ErrorMessage = "Minimum length for the Name is 2 characters")]
    [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters")]
    public string? Name { get; init; }
    
    [Required(ErrorMessage = "Race Description is a required field.")]
    [MinLength(2, ErrorMessage = "Minimum length for the Description is 2 characters")]
    [MaxLength(120, ErrorMessage = "Maximum length for the Description is 120 characters")]
    public string? Description { get; init; }
        
    [Required(ErrorMessage = "Animal Id is a required field.")]
    public int AnimalId { get; init; }
}