using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeysToGames.Service.UnitTests
{
    public static class KeysToGamesApiEndPoints
    {
        public const string AuthorizeUserEndpoint = "auth/login";
        public const string RegisterUserEndpoint = "auth/register";
        public const string GetAllUsersEndpoint = "users";
        public const string GetAllGamesEndpoint = "games";
    }
}
