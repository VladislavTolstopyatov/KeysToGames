using AutoMapper;
using KeysToGames.BL.Games.Entities;
using KeysToGames.Controllers.Games.Entities;

namespace KeysToGames.Mapper
{
    public class GamesServiceProfile : Profile
    {
        public GamesServiceProfile() 
        {
            CreateMap<GameFilter, GameModelFilter>();

            CreateMap<CreateGameBody, CreateGameModel>();

            CreateMap<UpdateGameBody, GameModel>().ForMember(x => x.Description, y => y.MapFrom(th => th.Description))
                .ForMember(x => x.Price, y => y.MapFrom(th => th.Price));
        }
    }
}
