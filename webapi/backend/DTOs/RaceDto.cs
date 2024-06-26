namespace backend.DTOs;

public record RaceDto
{
    public int Id { get; init; }
    public string? Name { get; init; }
    public string? Description { get; init; }
    public AnimalDto? Animal { get; init; }
}