using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public sealed class Config
    {
        private Dictionary<string, string> _config = new Dictionary<string, string>();

        private Config() 
        {          
            var config = ConfigurationManager.AppSettings;
            foreach (string c in config)
            {
                _config.Add(c, config.Get(c));
            }
        }

        private static Config _instance;

        public static Config GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Config();
            }
            return _instance;
        }

        public string GetValue(string key)
        {
            return _config.ContainsKey(key) ? _config[key] : "";
        }

        public bool hasKey(string key)
        {
            return _config.ContainsKey(key);
        }

        public int GetIntValue(string key)
        {
            return _config.ContainsKey(key) ? int.Parse(_config[key]) : 0;
        }
    }

}
