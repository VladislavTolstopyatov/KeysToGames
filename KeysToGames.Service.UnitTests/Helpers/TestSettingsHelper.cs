using KeysToGames.WebAPI.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeysToGames.Service.UnitTests.Helpers
{
    public static  class TestSettingsHelper
    {
        public static KeysToGamesSettings GetSettings()
        {
            return KeysToGamesSettingsReader.Read(ConfigurationHelper.GetConfiguration());
        }
    }
}
