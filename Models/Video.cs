namespace TagProLeague.Models
{
    public class Video : Document
    {
        public string TwitchUrl { get; set; }
        public string YouTubeUrl { get; set; }
        public string Streamer { get; set; }
        public string Series { get; set; }
    }
}
