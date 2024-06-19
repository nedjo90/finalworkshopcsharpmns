using backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.Repository.Configuration;

public class RaceConfiguration : IEntityTypeConfiguration<Race>
{
    public void Configure(EntityTypeBuilder<Race> builder)
    {
        builder.HasData(
            new Race
            {
                Id = 1,
                Name = "Labrador Retriever",
                Description =
                    "Le Labrador Retriever est une race de chien de taille moyenne à grande, connue pour son tempérament doux et amical. Ils sont intelligents, faciles à dresser, et excellents avec les enfants, ce qui en fait des animaux de compagnie idéaux. Les Labradors ont un pelage court et dense, souvent noir, jaune ou chocolat.",
                AnimalId = 1
            },
            new Race
            {
                Id = 2,
                Name = "Chihuahua",
                Description =
                    " Le Chihuahua est l'une des plus petites races de chiens au monde. Ils sont alertes, vifs et très loyaux envers leurs propriétaires. Les Chihuahuas peuvent avoir un pelage court ou long et sont souvent de couleurs variées. Leur petite taille les rend adaptés à la vie en appartement, mais ils ont besoin de socialisation pour éviter le comportement territorial.",
                AnimalId = 1
            },
            new Race
            {
                Id = 3,
                Name = "Border Collie",
                Description =
                    "Le Border Collie est un chien de berger extrêmement intelligent et énergique. Ils sont connus pour leur capacité à apprendre rapidement et exceller dans les activités d'agilité et de travail sur le terrain. Leur pelage peut être lisse ou ondulé, généralement noir et blanc, bien que d'autres couleurs existent.",
                AnimalId = 1
            },
            new Race
            {
                Id = 4,
                Name = "Bulldog Anglais",
                Description =
                    "Le Bulldog Anglais est une race de chien de taille moyenne, connue pour son apparence robuste et ses plis caractéristiques. Ils sont généralement calmes, courageux et affectueux. Leur pelage est court et peut être de diverses couleurs, y compris le blanc, le fauve et le bringé. Les Bulldogs ont besoin de soins particuliers en raison de leurs problèmes de santé potentiels liés à leur morphologie.",
                AnimalId = 1
            },
            new Race
            {
                Id = 5,
                Name = "Caniche (Poodle)",
                Description =
                    "Le Caniche est une race de chien très intelligente et élégante, disponible en trois tailles : standard, miniature et toy. Ils sont connus pour leur pelage bouclé, hypoallergénique, qui nécessite un toilettage régulier. Les Caniches sont vifs, faciles à dresser et excellents dans les compétitions d'agilité et d'obéissance.",
                AnimalId = 1
            },
            new Race
            {
                Id = 6,
                Name = "Siamois",
                Description =
                    "Le Siamois est une race de chat élégante et sociable, connue pour ses yeux bleus perçants et son pelage court de couleur crème avec des points foncés sur les oreilles, le museau, les pattes et la queue. Ils sont très vocaux, intelligents et aiment être au centre de l'attention.",
                AnimalId = 2
            },
            new Race
            {
                Id = 7,
                Name = "Maine Coon",
                Description =
                    "Le Maine Coon est l'une des plus grandes races de chats domestiques. Ils sont connus pour leur taille imposante, leur queue touffue et leur pelage long et soyeux. Les Maine Coons sont affectueux, joueurs et s'entendent bien avec les enfants et autres animaux.",
                AnimalId = 2
            },
            new Race
            {
                Id = 8,
                Name = "Bengal",
                Description =
                    "Le Bengal est une race de chat énergique et athlétique, célèbre pour son pelage tacheté ou marbré rappelant celui d'un léopard. Ils sont intelligents, curieux et aiment grimper et jouer dans l'eau. Les Bengals sont très actifs et nécessitent beaucoup de stimulation.",
                AnimalId = 2
            },
            new Race
            {
                Id = 9,
                Name = "Persan",
                Description =
                    "Le Persan est une race de chat domestique réputée pour son visage plat et son pelage long et soyeux. Ils sont généralement calmes, affectueux et préfèrent la vie en intérieur. Les Persans nécessitent un entretien régulier de leur fourrure pour éviter les nœuds et les enchevêtrements.",
                AnimalId = 2
            },
            new Race
            {
                Id = 10,
                Name = "Sphynx",
                Description =
                    "Le Sphynx est une race de chat sans poils, connue pour son apparence unique et son caractère affectueux. Ils sont énergiques, curieux et aiment se blottir contre leurs propriétaires pour se réchauffer. Le Sphynx nécessite des bains réguliers pour garder sa peau propre et en bonne santé.",
                AnimalId = 2
            }
        );
    }
}