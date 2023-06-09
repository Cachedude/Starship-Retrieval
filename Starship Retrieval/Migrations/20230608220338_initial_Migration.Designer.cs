﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StarshipRetrieval.Data;

#nullable disable

namespace StarshipRetrieval.Migrations
{
    [DbContext(typeof(StarWarsContext))]
    [Migration("20230608220338_initial_Migration")]
    partial class initial_Migration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FilmPeople", b =>
                {
                    b.Property<int>("CharactersID")
                        .HasColumnType("int");

                    b.Property<int>("FilmsID")
                        .HasColumnType("int");

                    b.HasKey("CharactersID", "FilmsID");

                    b.HasIndex("FilmsID");

                    b.ToTable("FilmPeople");
                });

            modelBuilder.Entity("FilmPlanet", b =>
                {
                    b.Property<int>("FilmsID")
                        .HasColumnType("int");

                    b.Property<int>("PlanetsID")
                        .HasColumnType("int");

                    b.HasKey("FilmsID", "PlanetsID");

                    b.HasIndex("PlanetsID");

                    b.ToTable("FilmPlanet");
                });

            modelBuilder.Entity("FilmSpecies", b =>
                {
                    b.Property<int>("FilmsID")
                        .HasColumnType("int");

                    b.Property<int>("SpeciesID")
                        .HasColumnType("int");

                    b.HasKey("FilmsID", "SpeciesID");

                    b.HasIndex("SpeciesID");

                    b.ToTable("FilmSpecies");
                });

            modelBuilder.Entity("FilmStarShip", b =>
                {
                    b.Property<int>("FilmsID")
                        .HasColumnType("int");

                    b.Property<int>("StarShipsID")
                        .HasColumnType("int");

                    b.HasKey("FilmsID", "StarShipsID");

                    b.HasIndex("StarShipsID");

                    b.ToTable("FilmStarShip");
                });

            modelBuilder.Entity("FilmVehicle", b =>
                {
                    b.Property<int>("FilmsID")
                        .HasColumnType("int");

                    b.Property<int>("VehiclesID")
                        .HasColumnType("int");

                    b.HasKey("FilmsID", "VehiclesID");

                    b.HasIndex("VehiclesID");

                    b.ToTable("FilmVehicle");
                });

            modelBuilder.Entity("PeopleSpecies", b =>
                {
                    b.Property<int>("PeopleID")
                        .HasColumnType("int");

                    b.Property<int>("SpeciesID")
                        .HasColumnType("int");

                    b.HasKey("PeopleID", "SpeciesID");

                    b.HasIndex("SpeciesID");

                    b.ToTable("PeopleSpecies");
                });

            modelBuilder.Entity("PeopleStarShip", b =>
                {
                    b.Property<int>("PilotsID")
                        .HasColumnType("int");

                    b.Property<int>("StarShipsID")
                        .HasColumnType("int");

                    b.HasKey("PilotsID", "StarShipsID");

                    b.HasIndex("StarShipsID");

                    b.ToTable("PeopleStarShip");
                });

            modelBuilder.Entity("PeopleVehicle", b =>
                {
                    b.Property<int>("PilotsID")
                        .HasColumnType("int");

                    b.Property<int>("VehiclesID")
                        .HasColumnType("int");

                    b.HasKey("PilotsID", "VehiclesID");

                    b.HasIndex("VehiclesID");

                    b.ToTable("PeopleVehicle");
                });

            modelBuilder.Entity("StarshipRetrieval.Models.Film", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateEdited")
                        .HasColumnType("datetime2");

                    b.Property<string>("Director")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EpisodeID")
                        .HasColumnType("int");

                    b.Property<int>("FilmID")
                        .HasColumnType("int");

                    b.Property<string>("OpeningCrawl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Producer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Film", (string)null);
                });

            modelBuilder.Entity("StarshipRetrieval.Models.People", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("BirthYear")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateEdited")
                        .HasColumnType("datetime2");

                    b.Property<string>("EyeColor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HairColor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Height")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("HomeWorldID")
                        .HasColumnType("int");

                    b.Property<string>("Mass")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PeopleID")
                        .HasColumnType("int");

                    b.Property<string>("SkinColor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("HomeWorldID");

                    b.ToTable("Person", (string)null);
                });

            modelBuilder.Entity("StarshipRetrieval.Models.Planet", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Climate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateEdited")
                        .HasColumnType("datetime2");

                    b.Property<string>("Diameter")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gravity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrbitalPeriod")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlanetID")
                        .HasColumnType("int");

                    b.Property<string>("Population")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RotationPeriod")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SurfaceWater")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Terrain")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Planet", (string)null);
                });

            modelBuilder.Entity("StarshipRetrieval.Models.Species", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("AverageHeight")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AverageLifespan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Classification")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateEdited")
                        .HasColumnType("datetime2");

                    b.Property<string>("Designation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EyeColors")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HairColors")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("HomeWorldID")
                        .HasColumnType("int");

                    b.Property<string>("Language")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SkinColors")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SpeciesID")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("HomeWorldID");

                    b.ToTable("Species", (string)null);
                });

            modelBuilder.Entity("StarshipRetrieval.Models.StarShip", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("CargoCapacity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Consumables")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CostInCredits")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Crew")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateEdited")
                        .HasColumnType("datetime2");

                    b.Property<string>("HyperdriveRating")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Length")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MGLT")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaxAtmospheringSpeed")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Passengers")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ShipID")
                        .HasColumnType("int");

                    b.Property<string>("StarshipClass")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("StarShip", (string)null);
                });

            modelBuilder.Entity("StarshipRetrieval.Models.Vehicle", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("CargoCapacity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Consumables")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CostInCredits")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Crew")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateEdited")
                        .HasColumnType("datetime2");

                    b.Property<string>("Length")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Manufacturer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaxAtmospheringSpeed")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Passengers")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VehicleClass")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VehicleID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Vehicle", (string)null);
                });

            modelBuilder.Entity("FilmPeople", b =>
                {
                    b.HasOne("StarshipRetrieval.Models.People", null)
                        .WithMany()
                        .HasForeignKey("CharactersID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StarshipRetrieval.Models.Film", null)
                        .WithMany()
                        .HasForeignKey("FilmsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FilmPlanet", b =>
                {
                    b.HasOne("StarshipRetrieval.Models.Film", null)
                        .WithMany()
                        .HasForeignKey("FilmsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StarshipRetrieval.Models.Planet", null)
                        .WithMany()
                        .HasForeignKey("PlanetsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FilmSpecies", b =>
                {
                    b.HasOne("StarshipRetrieval.Models.Film", null)
                        .WithMany()
                        .HasForeignKey("FilmsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StarshipRetrieval.Models.Species", null)
                        .WithMany()
                        .HasForeignKey("SpeciesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FilmStarShip", b =>
                {
                    b.HasOne("StarshipRetrieval.Models.Film", null)
                        .WithMany()
                        .HasForeignKey("FilmsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StarshipRetrieval.Models.StarShip", null)
                        .WithMany()
                        .HasForeignKey("StarShipsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FilmVehicle", b =>
                {
                    b.HasOne("StarshipRetrieval.Models.Film", null)
                        .WithMany()
                        .HasForeignKey("FilmsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StarshipRetrieval.Models.Vehicle", null)
                        .WithMany()
                        .HasForeignKey("VehiclesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PeopleSpecies", b =>
                {
                    b.HasOne("StarshipRetrieval.Models.People", null)
                        .WithMany()
                        .HasForeignKey("PeopleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StarshipRetrieval.Models.Species", null)
                        .WithMany()
                        .HasForeignKey("SpeciesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PeopleStarShip", b =>
                {
                    b.HasOne("StarshipRetrieval.Models.People", null)
                        .WithMany()
                        .HasForeignKey("PilotsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StarshipRetrieval.Models.StarShip", null)
                        .WithMany()
                        .HasForeignKey("StarShipsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PeopleVehicle", b =>
                {
                    b.HasOne("StarshipRetrieval.Models.People", null)
                        .WithMany()
                        .HasForeignKey("PilotsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StarshipRetrieval.Models.Vehicle", null)
                        .WithMany()
                        .HasForeignKey("VehiclesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StarshipRetrieval.Models.People", b =>
                {
                    b.HasOne("StarshipRetrieval.Models.Planet", "HomeWorld")
                        .WithMany("Residents")
                        .HasForeignKey("HomeWorldID");

                    b.Navigation("HomeWorld");
                });

            modelBuilder.Entity("StarshipRetrieval.Models.Species", b =>
                {
                    b.HasOne("StarshipRetrieval.Models.Planet", "HomeWorld")
                        .WithMany()
                        .HasForeignKey("HomeWorldID");

                    b.Navigation("HomeWorld");
                });

            modelBuilder.Entity("StarshipRetrieval.Models.Planet", b =>
                {
                    b.Navigation("Residents");
                });
#pragma warning restore 612, 618
        }
    }
}
