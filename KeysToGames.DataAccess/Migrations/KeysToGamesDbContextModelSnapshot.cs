﻿// <auto-generated />
using System;
using KeysToGames.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KeysToGames.DataAccess.Migrations
{
    [DbContext(typeof(KeysToGamesDbContext))]
    partial class KeysToGamesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("KeysToGames.DataAccess.Entities.AdminEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ExternalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("PasswordHash")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExternalId")
                        .IsUnique();

                    b.HasIndex("Id");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("KeysToGames.DataAccess.Entities.DealEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfDeal")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ExternalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PromocodeId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExternalId")
                        .IsUnique();

                    b.HasIndex("GameId");

                    b.HasIndex("PromocodeId");

                    b.HasIndex("UserId");

                    b.ToTable("Deals");
                });

            modelBuilder.Entity("KeysToGames.DataAccess.Entities.GameEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfRelease")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeveloperCompany")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ExternalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ExternalId")
                        .IsUnique();

                    b.HasIndex("GenreId");

                    b.HasIndex("Id");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("KeysToGames.DataAccess.Entities.GenreEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ExternalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ExternalId")
                        .IsUnique();

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("KeysToGames.DataAccess.Entities.KeyEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ExternalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActual")
                        .HasColumnType("bit");

                    b.Property<string>("KeyStr")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ExternalId")
                        .IsUnique();

                    b.HasIndex("GameId");

                    b.HasIndex("Id");

                    b.ToTable("Keys");
                });

            modelBuilder.Entity("KeysToGames.DataAccess.Entities.PromocodeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("DiscountProcent")
                        .HasColumnType("int");

                    b.Property<Guid>("ExternalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("PromocodeStr")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Promocodes");
                });

            modelBuilder.Entity("KeysToGames.DataAccess.Entities.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ExternalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<float>("MoneyBalance")
                        .HasColumnType("real");

                    b.Property<int>("PasswordHash")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExternalId")
                        .IsUnique();

                    b.HasIndex("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("KeysToGames.DataAccess.Entities.DealEntity", b =>
                {
                    b.HasOne("KeysToGames.DataAccess.Entities.GameEntity", "Game")
                        .WithMany("Deals")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KeysToGames.DataAccess.Entities.PromocodeEntity", "Promocode")
                        .WithMany("Deals")
                        .HasForeignKey("PromocodeId");

                    b.HasOne("KeysToGames.DataAccess.Entities.UserEntity", "User")
                        .WithMany("Deals")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Promocode");

                    b.Navigation("User");
                });

            modelBuilder.Entity("KeysToGames.DataAccess.Entities.GameEntity", b =>
                {
                    b.HasOne("KeysToGames.DataAccess.Entities.GenreEntity", "Genre")
                        .WithMany("Games")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("KeysToGames.DataAccess.Entities.KeyEntity", b =>
                {
                    b.HasOne("KeysToGames.DataAccess.Entities.GameEntity", "Game")
                        .WithMany("Keys")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");
                });

            modelBuilder.Entity("KeysToGames.DataAccess.Entities.GameEntity", b =>
                {
                    b.Navigation("Deals");

                    b.Navigation("Keys");
                });

            modelBuilder.Entity("KeysToGames.DataAccess.Entities.GenreEntity", b =>
                {
                    b.Navigation("Games");
                });

            modelBuilder.Entity("KeysToGames.DataAccess.Entities.PromocodeEntity", b =>
                {
                    b.Navigation("Deals");
                });

            modelBuilder.Entity("KeysToGames.DataAccess.Entities.UserEntity", b =>
                {
                    b.Navigation("Deals");
                });
#pragma warning restore 612, 618
        }
    }
}
