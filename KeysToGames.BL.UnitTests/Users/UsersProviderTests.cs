using KeysToGames.BL.Games;
using KeysToGames.BL.UnitTests.Mapper;
using KeysToGames.DataAccess.Entities;
using KeysToGames.DataAccess;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using KeysToGames.BL.Users;

namespace KeysToGames.BL.UnitTests.Users
{
    [TestFixture]


    public class UsersProviderTests
    {

        public void testGetAllUsers()
        {
            Expression expression = null;
            Mock<IRepository<UserEntity>> usersRepository = new Mock<IRepository<UserEntity>>();
            usersRepository.Setup(x => x.GetAll(It.IsAny<Expression<Func<UserEntity, bool>>>()))
                    .Callback((Expression<Func<UserEntity, bool>> x) => { expression = x; });
            var usersProvider = new UsersProvider(usersRepository.Object, MapperHelper.Mapper);
            var users = usersProvider.GetAllUsers();

            usersRepository.Verify(x => x.GetAll(It.IsAny<Expression<Func<UserEntity, bool>>>()), Times.Exactly(1));
        }
    }
}
