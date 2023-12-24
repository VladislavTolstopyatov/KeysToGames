using KeysToGames.BL.Games;
using KeysToGames.BL.UnitTests.Mapper;
using KeysToGames.DataAccess;
using KeysToGames.DataAccess.Entities;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KeysToGames.BL.UnitTests.Games
{
    [TestFixture]
    public class GamesProviderTests
    {
        [Test]
        public void TestGetAllGames()
        {
            Expression expression = null;
            Mock<IRepository<GameEntity>> gamesRepository = new Mock<IRepository<GameEntity>>();
            gamesRepository.Setup(x => x.GetAll(It.IsAny<Expression<Func<GameEntity, bool>>>()))
                .Callback((Expression<Func<GameEntity, bool>> x) => { expression = x; });
            var gamesProvider = new GamesProvider(gamesRepository.Object, MapperHelper.Mapper);
            var games = gamesProvider.GetAllGames();

            gamesRepository.Verify(x => x.GetAll(It.IsAny<Expression<Func<GameEntity, bool>>>()), Times.Exactly(1));
        }
    }
}
