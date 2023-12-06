using AutoMapper;
using KeysToGames.BL.Games.Entities;
using KeysToGames.BL.Users.Entities;
using KeysToGames.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeysToGames.BL.Mapper
{
    public class UsersBLProfile : Profile
    {
        public UsersBLProfile() 
        {
            CreateMap<UserEntity, UserModel>().ForMember(x => x.id, y => y.MapFrom(src => src.ExternalId));

                CreateMap<CreateUserModel, UserEntity>().ForMember(x => x.Id, y => y.Ignore())
        .ForMember(x => x.ExternalId, y => y.Ignore())
        .ForMember(x => x.CreationTime, y => y.Ignore())
        .ForMember(x => x.ModificationTime, y => y.Ignore());
        }

    }
}
