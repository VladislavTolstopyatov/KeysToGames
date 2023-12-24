using AutoMapper;
using KeysToUsers.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeysToGames.BL.UnitTests.Mapper
{
    public static class MapperHelper
    {
        static MapperHelper()
        {
            var config = new MapperConfiguration(x => x.AddProfile(typeof(UsersServiceProfile)));
            Mapper = new AutoMapper.Mapper(config);
        }

        public static IMapper Mapper { get; }
    }
}
