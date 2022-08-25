using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace BusinessLayer
{
    public static class Configuration
    {
        static public string ConfigurationString
        {
            get
            {
                ConfigurationManager configurationManager = new();
                //configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "./../../Presentation/ETicaretAPI.API"));
                // bu kısımda dosya yolu uzantısı hatası var
                configurationManager.AddJsonFile("appsettings.json");

                return configurationManager.GetConnectionString("MSSQL");
            }
        }
    }
}
