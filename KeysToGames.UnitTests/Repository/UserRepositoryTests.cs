/*
using FluentAssertions;
using KeysToGames.DataAccess;
using KeysToGames.DataAccess.Entities;
using NUnit.Framework;

namespace KeysToGames.UnitTests.Repository
{
    [TestFixture]
    [Category("Integration")]
    public class UserRepositoryTests : RepositoryTestBase
    {
        [Test]
        public void GetAllUsersTest()
        {
            //prepare
            using var context = DbContextFactory.CreateDbContext();

            var users = new UserEntity[]
            {
            new UserEntity()
            {
                Login = "Test1",
                PasswordHash = 1,             
                MoneyBalance = 1,
                CardNumber = "808",
                ExternalId = Guid.NewGuid()
            },
            new UserEntity()
            {
                Login = "Test2",
                PasswordHash = 2,                
                MoneyBalance = 1,
                CardNumber = "809",
                ExternalId = Guid.NewGuid()
            },
            new UserEntity()
            {
                Login = "Test3",
                PasswordHash = 3,                
                MoneyBalance = 1,
                CardNumber = "810",
                ExternalId = Guid.NewGuid()
            },
            };
            context.Users.AddRange(users);
            context.SaveChanges();

            //execute
            var repository = new Repository<UserEntity>(DbContextFactory);
            var actualUsers = repository.GetAll(); // toArray();

            //assert        
            actualUsers.Equals(users);
            //actualUsers.Should().BeEquivalentTo(users); // не выполянется(
        }

        [Test]
        public void GetAllUsersWithFilterTest()
        {
            //prepare
            using var context = DbContextFactory.CreateDbContext();

            var users = new UserEntity[]
            {
            new UserEntity()
            {
                Login = "GGTest1",
                PasswordHash = 1,
                MoneyBalance = 1,
                CardNumber = "808",
                ExternalId = Guid.NewGuid()
            },
            new UserEntity()
            {
                Login = "GGTest2",
                PasswordHash = 2,
                MoneyBalance = 1,
                CardNumber = "808",
                ExternalId = Guid.NewGuid()
            },
            new UserEntity()
            {
                Login = "LOSETest3",
                PasswordHash = 3,
                MoneyBalance = 1,
                CardNumber = "808",
                ExternalId = Guid.NewGuid()
            },
            };
            context.Users.AddRange(users);
            context.SaveChanges();

            //execute
            var repository = new Repository<UserEntity>(DbContextFactory);
            var actualUsers = repository.GetAll(user => user.Login.StartsWith("GG"));

            //assert
            actualUsers.Should().BeEquivalentTo(users.Where(user => user.Login.StartsWith("GG")));
        }

        [Test]
        public void SaveNewUserTest()
        {
            //prepare
            using var context = DbContextFactory.CreateDbContext();

            var user = new UserEntity()
            {
                Login = "TestNewUser",
                PasswordHash = 1,
                MoneyBalance = 1,
                CardNumber = "808",
                ExternalId = Guid.NewGuid()
            };
            var repository = new Repository<UserEntity>(DbContextFactory);

            //execute
            repository.Save(user);

            //assert
            var actualUser = context.Users.SingleOrDefault();
            actualUser.Should().BeEquivalentTo(user, options => options
                            .Excluding(user => user.Id)
                            .Excluding(user => user.ModificationTime)
                            .Excluding(user => user.CreationTime)
                            .Excluding(user => user.ExternalId));
            actualUser.Id.Should().NotBe(default);
            actualUser.ModificationTime.Should().NotBe(default);
            actualUser.CreationTime.Should().NotBe(default);
            actualUser.ExternalId.Should().NotBe(Guid.Empty);
        }

        [Test]
        public void UpdateUserTest()
        {
            //prepare
            using var context = DbContextFactory.CreateDbContext();

            var user = new UserEntity()
            {
                Login = "TestLogin",
                PasswordHash = 1,
                MoneyBalance = 1,
                CardNumber = "808",
                ExternalId = Guid.NewGuid()
            };
            context.Users.Add(user);
            context.SaveChanges();

            //execute

            user.Login = "TestNewLogin";
            var repository = new Repository<UserEntity>(DbContextFactory);
            repository.Save(user);

            //assert
            var actualUser = context.Users.SingleOrDefault();
            actualUser.Should().BeEquivalentTo(user);
        }

        [Test]
        public void DeleteUserTest()
        {
            //prepare
            using var context = DbContextFactory.CreateDbContext();

            var user = new UserEntity()
            {
                Login = "TestLogin",
                PasswordHash = 1,
                MoneyBalance = 1,
                CardNumber = "808",
                ExternalId = Guid.NewGuid()
            };
            context.Users.Add(user);
            context.SaveChanges();

            //execute

            var repository = new Repository<UserEntity>(DbContextFactory);
            repository.Delete(user);

            //assert
            context.Users.Count().Should().Be(0);
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
                context.Users.RemoveRange(context.Users);
                context.SaveChanges();
            }
        }
    }
}
*/