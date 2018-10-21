namespace TagProLeague.Models
{
    public class GameFormat : Document
    {
        public int Accel { get; set; }
        public int TopSpeed { get; set; }
        public int Bounce { get; set; }
        public int PlayerRespawn { get; set; }
        public int BoostRespawn { get; set; }
        public int BombRespawn { get; set; }
        public int PowerupRespawn { get; set; }
        public int PotatoTime { get; set; }
        public int PowerupDelay { get; set; }
        public bool NoScript { get; set; }
        public bool RespawnWarnings { get; set; }
    }
}
