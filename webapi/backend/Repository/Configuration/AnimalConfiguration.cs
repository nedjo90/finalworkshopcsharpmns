using backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.Repository.Configuration;

public class AnimalConfiguration : IEntityTypeConfiguration<Animal>
{
    public void Configure(EntityTypeBuilder<Animal> builder)
    {
        builder.HasData(
            new Animal()
            {
                Id = 1,
                Name = "Chien",
                Description =
                    "animal naif à quatre pattes, bon renifleur",
            },
            new Animal()
            {
                Id = 2,
                Name = "Chat",
                Description =
                    "monstre avec des griffes à quatre pattes, 7 vies",
            }
        );
    }
}

//     - ./mysql-scripts:/docker-entrypoint-initdb.d