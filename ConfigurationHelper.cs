using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace LabExercise8
{
    public class ConfigurationHelper
    {
        private static ConfigurationHelper INSTANCE;

        public IConfigurationRoot Configuration { get; set; }

        private ConfigurationHelper()
        {
            Configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").AddUserSecrets<Program>().Build();    
        }

        public static ConfigurationHelper Instance()
        {
            if(INSTANCE == null)
            {
                INSTANCE = new ConfigurationHelper();
            }
            return INSTANCE;
        }

        public T GetProperty<T>(string propertyName)
        {
            return Configuration.GetValue<T>(propertyName);
        }
    }
}
