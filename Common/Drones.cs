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

        public void Add(Drone drone)
        {
            if (!_drones.ContainsKey(drone.ComputerId))
            {
                _drones.Add(drone.ComputerId, drone);
            }
        }
    }
}
