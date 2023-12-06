using AutoMapper;
using KeysToGames.BL.Games.Entities;
using KeysToGames.BL.Users.Entities;
using KeysToGames.DataAccess;
using KeysToGames.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeysToGames.BL.Users
{
    public class UsersManager : IUsersManager
    {
        private readonly IRepository<UserEntity> _userRepository;
        private readonly IMapper _mapper;

        public UsersManager(IRepository<UserEntity> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public UserModel CreateUser(CreateUserModel game)
        {
            var entity = _mapper.Map<UserEntity>(game);

            _userRepository.Save(entity); // id, creationTime, external id

            return _mapper.Map<UserModel>(game);
        }

        public void DeleteUser(Guid id)
        {
            var entity = _userRepository.GetById(id);

            if (entity is null)
            {
                throw new ArgumentException("User not found");
            }
            _userRepository.Delete(entity);
        }

        public UserModel UpdateUser(Guid id, UpdateUserModel model)
        {
            var entity = _userRepository.GetById(id);

            if (entity is null)
            {
                throw new ArgumentException("Game not found");
            }

            entity.MoneyBalance = model.MoneyBalance;

            // ? modification time,id,external Id?

            _userRepository.Save(entity);

            return _mapper.Map<UserModel>(entity);
        }
    }
}
