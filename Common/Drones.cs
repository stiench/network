using System.Collections.Generic;

namespace Common
{
    public class Drones
    {
        private Dictionary<string, Drone> _drones;
        private Drones()
        {
            _drones = new Dictionary<string, Drone>();
        }

        private static Drones _instance;

        public static Drones GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Drones();
            }
            return _instance;
        }

        public void Add(string key, string ip)
        {
            if (!_drones.ContainsKey(key))
            {
                _drones.Add(key, new Drone(key, ip));
            }
        }
    }
}
