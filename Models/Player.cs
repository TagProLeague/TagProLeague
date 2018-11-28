using System;
using System.Collections.Generic;

namespace TagProLeague.Models
{
    public class Player : Document
    {
        public DateTimeOffset? PlayedSince { get; set; }
        public DateTimeOffset? LastOnline { get; set; }
        public string ImageUrl { get; set; }
        public ContactProfile ContactProfile { get; set; }
        public StreamProfile StreamProfile { get; set; }
        public List<string> Leagues { get; set; }
        public List<string> Teams { get; set; }
        public List<string> Series { get; set; }
        public List<string> Maps { get; set; }
        public List<string> Awards { get; set; }
        public List<string> Games { get; set; }
        public string TotalStatline { get; set; }
    }

    public class ContactProfile
    {
        public string Reddit { get; set; }
        public string Discord { get; set; }
    }

    public class StreamProfile
    {
        public string Twitch { get; set; }
        public List<string> Videos { get; set; }
    }
}
