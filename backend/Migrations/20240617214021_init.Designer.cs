﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using backend.Repository;

#nullable disable

namespace backend.Migrations
{
    [DbContext(typeof(BackendContext))]
    [Migration("20240617214021_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("backend.Models.Animal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<int>("RaceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RaceId");

                    b.ToTable("Animals");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "animal naif à quatre pattes, bon renifleur",
                            Name = "Chien",
                            RaceId = 1
                        },
                        new
                        {
                            Id = 2,
                            Description = "monstre avec des griffes à quatre pattes, 7 vies",
                            Name = "Chat",
                            RaceId = 1
                        });
                });

            modelBuilder.Entity("backend.Models.Race", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("RaceId");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.HasKey("Id");

                    b.ToTable("Races");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Le Labrador Retriever est une race de chien de taille moyenne à grande, connue pour son tempérament doux et amical. Ils sont intelligents, faciles à dresser, et excellents avec les enfants, ce qui en fait des animaux de compagnie idéaux. Les Labradors ont un pelage court et dense, souvent noir, jaune ou chocolat.",
                            Name = "Labrador Retriever"
                        },
                        new
                        {
                            Id = 2,
                            Description = " Le Chihuahua est l'une des plus petites races de chiens au monde. Ils sont alertes, vifs et très loyaux envers leurs propriétaires. Les Chihuahuas peuvent avoir un pelage court ou long et sont souvent de couleurs variées. Leur petite taille les rend adaptés à la vie en appartement, mais ils ont besoin de socialisation pour éviter le comportement territorial.",
                            Name = "Chihuahua"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Le Border Collie est un chien de berger extrêmement intelligent et énergique. Ils sont connus pour leur capacité à apprendre rapidement et exceller dans les activités d'agilité et de travail sur le terrain. Leur pelage peut être lisse ou ondulé, généralement noir et blanc, bien que d'autres couleurs existent.",
                            Name = "Border Collie"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Le Bulldog Anglais est une race de chien de taille moyenne, connue pour son apparence robuste et ses plis caractéristiques. Ils sont généralement calmes, courageux et affectueux. Leur pelage est court et peut être de diverses couleurs, y compris le blanc, le fauve et le bringé. Les Bulldogs ont besoin de soins particuliers en raison de leurs problèmes de santé potentiels liés à leur morphologie.",
                            Name = "Bulldog Anglais"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Le Caniche est une race de chien très intelligente et élégante, disponible en trois tailles : standard, miniature et toy. Ils sont connus pour leur pelage bouclé, hypoallergénique, qui nécessite un toilettage régulier. Les Caniches sont vifs, faciles à dresser et excellents dans les compétitions d'agilité et d'obéissance.",
                            Name = "Caniche (Poodle)"
                        },
                        new
                        {
                            Id = 6,
                            Description = "Le Siamois est une race de chat élégante et sociable, connue pour ses yeux bleus perçants et son pelage court de couleur crème avec des points foncés sur les oreilles, le museau, les pattes et la queue. Ils sont très vocaux, intelligents et aiment être au centre de l'attention.",
                            Name = "Siamois"
                        },
                        new
                        {
                            Id = 7,
                            Description = "Le Maine Coon est l'une des plus grandes races de chats domestiques. Ils sont connus pour leur taille imposante, leur queue touffue et leur pelage long et soyeux. Les Maine Coons sont affectueux, joueurs et s'entendent bien avec les enfants et autres animaux.",
                            Name = "Maine Coon"
                        },
                        new
                        {
                            Id = 8,
                            Description = "Le Bengal est une race de chat énergique et athlétique, célèbre pour son pelage tacheté ou marbré rappelant celui d'un léopard. Ils sont intelligents, curieux et aiment grimper et jouer dans l'eau. Les Bengals sont très actifs et nécessitent beaucoup de stimulation.",
                            Name = "Bengal"
                        },
                        new
                        {
                            Id = 9,
                            Description = "Le Persan est une race de chat domestique réputée pour son visage plat et son pelage long et soyeux. Ils sont généralement calmes, affectueux et préfèrent la vie en intérieur. Les Persans nécessitent un entretien régulier de leur fourrure pour éviter les nœuds et les enchevêtrements.",
                            Name = "Persan"
                        },
                        new
                        {
                            Id = 10,
                            Description = "Le Sphynx est une race de chat sans poils, connue pour son apparence unique et son caractère affectueux. Ils sont énergiques, curieux et aiment se blottir contre leurs propriétaires pour se réchauffer. Le Sphynx nécessite des bains réguliers pour garder sa peau propre et en bonne santé.",
                            Name = "Sphynx"
                        });
                });

            modelBuilder.Entity("backend.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("backend.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("backend.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backend.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("backend.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("backend.Models.Animal", b =>
                {
                    b.HasOne("backend.Models.Race", "Race")
                        .WithMany()
                        .HasForeignKey("RaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Race");
                });
#pragma warning restore 612, 618
        }
    }
}
