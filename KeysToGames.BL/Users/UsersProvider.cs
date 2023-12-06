using AutoMapper;
using KeysToGames.BL.Games.Entities;
using KeysToGames.DataAccess.Entities;
using KeysToGames.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeysToGames.BL.Users.Entities;

namespace KeysToGames.BL.Users
{
    public class UsersProvider : IUsersProvider
    {

        private readonly IRepository<UserEntity> _userRepository;
        private readonly IMapper _mapper;

        public UsersProvider(IRepository<UserEntity> usersRepository, IMapper mapper)
        {
            _userRepository = usersRepository;
            _mapper = mapper;
        }

        public UserModel GetUserInfo(Guid userId)
        {
            var user = _userRepository.GetById(userId);

            if (user is null)
            {
                throw new ArgumentException("User not found");
            }

            return _mapper.Map<UserModel>(user);
        }

        public IEnumerable<UserModel> GetAllUsers()
        {
            var users = _userRepository.GetAll();

            return _mapper.Map<IEnumerable<UserModel>>(users);
        }

        public IEnumerable<UserModel> GetAllUsersWithFilter(UserModelFilter filter)
        {
            int? minimumBalance = filter?.minimumBalance;
            int? maximumBalance = filter?.maximumBalance;


            var users = _userRepository.GetAll(x => x.MoneyBalance > minimumBalance && x.MoneyBalance < maximumBalance);

            return _mapper.Map<IEnumerable<UserModel>>(users);

        }
    }
}
