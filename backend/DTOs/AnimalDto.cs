using backend.Models;

namespace backend.DTOs;

public record AnimalDto
{
    public int Id { get; init; }
    public string? Name { get; init; }
    public string? Description { get; init; }
    public RaceDto? Race { get; init; }
}