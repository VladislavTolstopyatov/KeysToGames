using KeysToGames.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeysToGames.DataAccess
{
    public class KeysToGamesDbContext : DbContext
    {

        public DbSet<AdminEntity> Admins { get; set; }
        public DbSet<DealEntity> Deals { get; set; }
        public DbSet<GameEntity> Games { get; set; }
        public DbSet<GenreEntity> Genres { get; set; }
        public DbSet<KeyEntity> Keys { get; set; }
        public DbSet<PromocodeEntity> Promocodes { get; set; }
        public DbSet<UserEntity> Users { get; set; }


        public KeysToGamesDbContext(DbContextOptions options) : base(options) 
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // жанр игры
            modelBuilder.Entity<GenreEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<GenreEntity>().HasIndex(x=>x.ExternalId).IsUnique();

            // ключ для игры
            modelBuilder.Entity<KeyEntity>().HasIndex(x => x.Id);
            modelBuilder.Entity<KeyEntity>().HasIndex(x => x.ExternalId).IsUnique();

            modelBuilder.Entity<KeyEntity>().HasOne(x => x.Game).WithMany(x => x.Keys).
                HasForeignKey(x => x.GameId);


            // промокод
            modelBuilder.Entity<KeyEntity>().HasIndex(x => x.Id);
            modelBuilder.Entity<KeyEntity>().HasIndex(x => x.ExternalId).IsUnique();

            // Админы
            modelBuilder.Entity<AdminEntity>().HasIndex(x => x.Id);
            modelBuilder.Entity<AdminEntity>().HasIndex(x => x.ExternalId).IsUnique();

            // Пользователи
            modelBuilder.Entity<UserEntity>().HasIndex(x => x.Id);
            modelBuilder.Entity<UserEntity>().HasIndex(x => x.ExternalId).IsUnique();

            // Игры
            modelBuilder.Entity<GameEntity>().HasIndex(x => x.Id);
            modelBuilder.Entity<GameEntity>().HasIndex(x => x.ExternalId).IsUnique();

            modelBuilder.Entity<GameEntity>().HasOne(x => x.Genre).
                WithMany(x => x.Games).HasForeignKey(x => x.GenreId);

            // покупки 
            modelBuilder.Entity<DealEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<DealEntity>().HasIndex(x => x.ExternalId).IsUnique();


            modelBuilder.Entity<DealEntity>().HasOne(x=>x.User).WithMany(x=>x.Deals).
                HasForeignKey(x => x.UserId);

            modelBuilder.Entity<DealEntity>().HasOne(x => x.Promocode).WithMany(x => x.Deals).
                HasForeignKey(x => x.PromocodeId);

            modelBuilder.Entity<DealEntity>().HasOne(x => x.Game).WithMany(x => x.Deals).
                HasForeignKey(x => x.GameId);
    

        }
    }
}
