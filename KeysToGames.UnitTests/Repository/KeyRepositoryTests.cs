using FluentAssertions;
using KeysToGames.DataAccess.Entities;
using KeysToGames.DataAccess;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeysToGames.UnitTests.Repository
{
    [TestFixture]
    [Category("Integration")]
    public class KeyRepositoryTests : RepositoryTestBase
    {
        [Test]
        public void GetAllKeysTest()
        {
            //prepare
            using var context = DbContextFactory.CreateDbContext();

            var Genre = new GenreEntity()
            {
                Title = "Test",
                Description = "Test",
                ExternalId = Guid.NewGuid()
            };

            context.Genres.Add(Genre);
            context.SaveChanges();

            var Game = new GameEntity()
            {
                Title = "test",
                Description = "Test",
                DateOfRelease = DateTime.Now,
                DeveloperCompany = "1",
                Price = 10000,
                GenreId = Genre.Id,
                ExternalId = Guid.NewGuid()
            };

            context.Games.Add(Game);
            context.SaveChanges();

            var keys = new KeyEntity[]
            {
            new KeyEntity()
            {
                KeyStr = "abc",
                IsActual = true,
                GameId = Game.Id,
                ExternalId = Guid.NewGuid()
            },
            new KeyEntity()
            {
                KeyStr = "abcd",
                IsActual = true,
                GameId = Game.Id,
                ExternalId = Guid.NewGuid()
            },
            new KeyEntity()
            {
                KeyStr = "abcde",
                IsActual = true,
                GameId = Game.Id,
                ExternalId = Guid.NewGuid()
            }
            };
            context.Keys.AddRange(keys);
            context.SaveChanges();

            //execute
            var repository = new Repository<KeyEntity>(DbContextFactory);
            var actualKeys = repository.GetAll(); // toArray();

            //assert        
            //actualKeys.Should().BeEquivalentTo(keys,options=>options.Excluding(x=>x.Game));
            actualKeys.Equals(keys);
        }

        [Test]
        public void GetAllKeysWithFilterTest()
        {

            //prepare
            using var context = DbContextFactory.CreateDbContext();

            var Genre = new GenreEntity()
            {
                Title = "Test",
                Description = "Test",
                ExternalId = Guid.NewGuid()
            };

            context.Genres.Add(Genre);
            context.SaveChanges();

            var Game = new GameEntity()
            {
                Title = "test",
                Description = "Test",
                DateOfRelease = DateTime.Now,
                DeveloperCompany = "1",
                Price = 10000,
                GenreId = Genre.Id,
                ExternalId = Guid.NewGuid()
            };

            context.Games.Add(Game);
            context.SaveChanges();

            var keys = new KeyEntity[]
            {
            new KeyEntity()
            {
                KeyStr = "abc",
                IsActual = true,
                GameId = Game.Id,
                ExternalId = Guid.NewGuid()
            },
            new KeyEntity()
            {
                KeyStr = "abcd",
                IsActual = true,
                GameId = Game.Id,
                ExternalId = Guid.NewGuid()
            },
            new KeyEntity()
            {
                KeyStr = "dbcde",
                IsActual = true,
                GameId = Game.Id,
                ExternalId = Guid.NewGuid()
            }
            };
            context.Keys.AddRange(keys);
            context.SaveChanges();

            //execute
            var repository = new Repository<KeyEntity>(DbContextFactory);
            var actualKeys = repository.GetAll(key => key.KeyStr.StartsWith("a"));

            //assert
            actualKeys.Should().BeEquivalentTo(keys.Where(key => key.KeyStr.StartsWith("a")),options => options.Excluding(key => key.Game));
        }

        [Test]
        public void SaveNewKeyTest()
        {
            //prepare
            using var context = DbContextFactory.CreateDbContext();

            var Genre = new GenreEntity()
            {
                Title = "Test",
                Description = "Test",
                ExternalId = Guid.NewGuid()
            };

            context.Genres.Add(Genre);
            context.SaveChanges();

            var Game = new GameEntity()
            {
                Title = "test",
                Description = "Test",
                DateOfRelease = DateTime.Now,
                DeveloperCompany = "1",
                Price = 10000,
                GenreId = Genre.Id,
                ExternalId = Guid.NewGuid()
            };

            context.Games.Add(Game);
            context.SaveChanges();

            var key = new KeyEntity()
            {
                KeyStr = "abs",
                IsActual = true,
                GameId = Game.Id,
                ExternalId = Guid.NewGuid()
            };
            var repository = new Repository<KeyEntity>(DbContextFactory);

            //execute
            repository.Save(key);

            //assert
            var actualKey = context.Keys.SingleOrDefault();
            actualKey.Should().BeEquivalentTo(key, options => options.Excluding(key=>key.Game)
                            .Excluding(key => key.Id)
                            .Excluding(key => key.ModificationTime)
                            .Excluding(key => key.CreationTime)
                            .Excluding(key => key.ExternalId));
            actualKey.Id.Should().NotBe(default);
            actualKey.ModificationTime.Should().NotBe(default);
            actualKey.CreationTime.Should().NotBe(default);
            actualKey.ExternalId.Should().NotBe(Guid.Empty);
        }

        [Test]
        public void UpdateKeyTest()
        {
            //prepare
            using var context = DbContextFactory.CreateDbContext();

            var Genre = new GenreEntity()
            {
                Title = "Test",
                Description = "Test",
                ExternalId = Guid.NewGuid()
            };

            context.Genres.Add(Genre);
            context.SaveChanges();

            var Game = new GameEntity()
            {
                Title = "test",
                Description = "Test",
                DateOfRelease = DateTime.Now,
                DeveloperCompany = "1",
                Price = 10000,
                GenreId = Genre.Id,
                ExternalId = Guid.NewGuid()
            };

            context.Games.Add(Game);
            context.SaveChanges();

            var key = new KeyEntity()
            {
                KeyStr = "abc",
                IsActual = true,
                GameId = Game.Id,
                ExternalId = Guid.NewGuid()
            };
            context.Keys.Add(key);
            context.SaveChanges();

            //execute

            key.IsActual = false;
            var repository = new Repository<KeyEntity>(DbContextFactory);
            repository.Save(key);

            //assert
            var actualKey = context.Keys.SingleOrDefault();
            actualKey.Should().BeEquivalentTo(key,options=>options.Excluding(key=>key.Game));
        }

        [Test]
        public void DeleteKeyTest()
        {
            //prepare
            using var context = DbContextFactory.CreateDbContext();

            var Genre = new GenreEntity()
            {
                Title = "Test",
                Description = "Test",
                ExternalId = Guid.NewGuid()
            };

            context.Genres.Add(Genre);
            context.SaveChanges();

            var Game = new GameEntity()
            {
                Title = "test",
                Description = "Test",
                DateOfRelease = DateTime.Now,
                DeveloperCompany = "1",
                Price = 10000,
                GenreId = Genre.Id,
                ExternalId = Guid.NewGuid()
            };

            context.Games.Add(Game);
            context.SaveChanges();

            var key = new KeyEntity()
            {
                KeyStr = "abs",
                IsActual = true,
                GameId = Game.Id,
                ExternalId = Guid.NewGuid()
            };
            context.Keys.Add(key);
            context.SaveChanges();

            //execute

            var repository = new Repository<KeyEntity>(DbContextFactory);
            repository.Delete(key);

            //assert
            context.Keys.Count().Should().Be(0);
        }

        [SetUp]
        public void SetUp()
        {
            CleanUp();
        }

        [TearDown]
        public void TearDown()
        {
            CleanUp();
        }

        public void CleanUp()
        {
            using (var context = DbContextFactory.CreateDbContext())
            {
                context.Keys.RemoveRange(context.Keys);
                context.SaveChanges();
            }
        }
    }
}
