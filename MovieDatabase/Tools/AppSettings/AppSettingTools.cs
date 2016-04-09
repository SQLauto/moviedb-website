using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Tools.AppSettings
{
    public class AppSettingTools
    {
        public static string GetConnectionString(string name)
        {
            var connectionString = ConfigurationManager.ConnectionStrings[name];
            if (connectionString != null)
            {
                return connectionString.ConnectionString;
            }

            return null;
        }

        public static string Get(string name)
        {
            return ConfigurationManager.AppSettings[name];
        }
    }
}
