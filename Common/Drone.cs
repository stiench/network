namespace Common
{
    public class Drone
    {
        public string Name { get; set; }
        public string Ip { get; set; }

        public Drone(string name, string ip)
        {
            Name = name;
            Ip = ip;
        }
    }
}
