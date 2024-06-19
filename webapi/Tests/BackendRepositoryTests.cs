using backend.Contract;
using backend.Models;
using backend.Repository;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Tests;

public class BackendRepositoryTests
{
    [Fact]
    public void GetAllAnimalsAsync_ReturnsListOfAnimals_WithASingleAnimal()
    {
// Arrange
        Mock<IAnimalRepository> mockRepo = new Mock<IAnimalRepository>();
        mockRepo.Setup(repo => (repo.GetAllAnimalsAsync(false)))
            .Returns(Task.FromResult(GetAnimals()));
// Act
        List<Animal> result = mockRepo.Object.GetAllAnimalsAsync(false)
            .GetAwaiter()
            .GetResult()
            .ToList();
// Assert
        Assert.IsType<List<Animal>>(result);
        Assert.Single(result);
    }

    [Fact]
    public async Task GetAnimalAsync_ReturnsCorrectAnimal_WhenAnimalExists()
    {
        // Arrange
        int animalId = 1;
        bool trackChanges = false;

        // Crée un animal fictif correspondant à l'ID 1
        Animal expectedAnimal = new Animal
        {
            Id = 1,
            Name = "Chien",
            Description = "animal naif à quatre pattes, bon renifleur",
        };

        // Créer un mock pour IAnimalRepository
        Mock<IAnimalRepository> mockRepo = new Mock<IAnimalRepository>();

        // Configuration du mock pour retourner l'animal fictif lorsque GetAnimalAsync est appelé avec animalId
        mockRepo.Setup(repo => repo.GetAnimalAsync(animalId, trackChanges))
            .ReturnsAsync(expectedAnimal);

        // Act
        Animal result = await mockRepo.Object.GetAnimalAsync(animalId, trackChanges);

        // Assert
        Assert.NotNull(result); // Vérifie que result n'est pas null
        Assert.Equal(animalId, result.Id); // Vérifie que l'ID de l'animal est correct
        Assert.Equal(expectedAnimal.Name, result.Name); // Vérifie d'autres propriétés si nécessaire
    }

    [Fact]
    public async Task CreateAnimalAsync_AddsNewAnimalToInMemoryDatabase()
    {
        // Arrange
        DbContextOptions<BackendContext> options = new DbContextOptionsBuilder<BackendContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        using (var context = new BackendContext(options))
        {
            context.Database.EnsureCreated(); // S'assurer que la base de données est créée

            // Ajouter des données initiales si nécessaire
            context.Animals.AddRange(
                new Animal { Name = "Dog", Description = "Friendly animal"},
                new Animal { Name = "Cat", Description = "Playful animal"}
            );

            context.SaveChanges(); // Enregistrer les changements dans la base de données In-Memory
        }

        // Act
        using (var context = new BackendContext(options))
        {
            var animalRepository = new AnimalRepository(context);

            Animal newAnimal = new Animal
            {
                Name = "New Animal",
                Description = "Description of the new animal",
            };

            // Ajouter l'animal dans le repository
            animalRepository.CreateAnimal(newAnimal);
            context.SaveChanges(); // Sauvegarder les changements dans la base de données In-Memory
        }

        // Assert
        using (var context = new BackendContext(options))
        {
            // Vérifier le nombre total d'animaux dans la base de données

            // Vérifier si l'animal créé est bien dans la base de données
            var createdAnimal = await context.Animals.FirstOrDefaultAsync(a => a.Name == "New Animal");
            Assert.NotNull(createdAnimal); // Vérifie si l'animal créé existe
            Assert.Equal("New Animal", createdAnimal.Name); // Vérifie le nom de l'animal créé
            Assert.Equal("Description of the new animal", createdAnimal.Description); // Vérifie la description
            // Ajoutez d'autres assertions selon vos besoins pour d'autres propriétés
        }
    }
    
    [Fact]
    public async Task DeleteAnimalAsync_RemovesAnimalFromDatabase()
    {
        // Arrange
        DbContextOptions<BackendContext> options = new DbContextOptionsBuilder<BackendContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        // Seed the database with some animals
        using (var context = new BackendContext(options))
        {
            context.Animals.Add(new Animal { Id = 1, Name = "Dog", Description = "Friendly dog" });
            context.Animals.Add(new Animal { Id = 2, Name = "Cat", Description = "Playful cat" });
            await context.SaveChangesAsync();
        }

        // Act: Delete an animal
        using (var context = new BackendContext(options))
        {
            var animalRepository = new AnimalRepository(context);
            animalRepository.DeleteAnimal(new Animal { Id = 1 });
            await context.SaveChangesAsync();
        }

        // Assert: Check if the animal is deleted
        using (var context = new BackendContext(options))
        {
            var deletedAnimal = await context.Animals.FindAsync(1);
            Assert.Null(deletedAnimal); // Ensure the animal with Id 1 is no longer in the database
        }
    }
    
    [Fact]
    public async Task GetAnimalAsync_RetrievesCorrectAnimalFromDatabase()
    {
        // Arrange
        DbContextOptions<BackendContext> options = new DbContextOptionsBuilder<BackendContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        // Seed the database with some animals
        using (var context = new BackendContext(options))
        {
            context.Animals.Add(new Animal { Id = 1, Name = "Dog", Description = "Friendly dog" });
            context.Animals.Add(new Animal { Id = 2, Name = "Cat", Description = "Playful cat" });
            await context.SaveChangesAsync();
        }

        // Act: Retrieve an animal by ID
        using (var context = new BackendContext(options))
        {
            var animalRepository = new AnimalRepository(context);
            var retrievedAnimal = await animalRepository.GetAnimalAsync(1, trackChanges: false);

            // Assert: Check if the correct animal is retrieved
            Assert.NotNull(retrievedAnimal);  // Ensure an animal is retrieved
            Assert.Equal("Dog", retrievedAnimal.Name);  // Check if the retrieved animal has the expected name
        }
    }

    private IEnumerable<Animal> GetAnimals()
    {
        return new List<Animal>
        {
            new Animal
            {
                Id = new Random().Next(),
                Name = "AnimalName",
                Description = "Description of a animal",
            }
        };
    }
}