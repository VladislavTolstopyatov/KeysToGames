using AutoMapper;
using KeysToGames.BL.Games.Entities;
using KeysToGames.BL.Users.Entities;
using KeysToGames.Controllers.Games.Entities;
using KeysToGames.Controllers.Users.Entities;

namespace KeysToUsers.Mapper
{
    public class UsersServiceProfile : Profile
    {
        public UsersServiceProfile() 
        {
            CreateMap<UserFilter, UserModelFilter>();

            CreateMap<UpdateUserBody, UserModel>().ForMember(x=>x.MoneyBalance,y=>y.MapFrom(th=>th.MoneyBalance));
        }
    }
}
