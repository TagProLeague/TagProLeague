using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace TagProLeague.Models
{
    public class League
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public DateTime? StartedOn { get; set; }
        public DateTime? EndedOn { get; set; }
        public string Status { get; set; }
        public string CurrentSeason { get; set; }
        public LeagueFounder Founder { get; set; }
        public List<LeagueSeason> Seasons { get; set; }
        public List<LeagueTeam> Teams { get; set; }
        public List<LeaguePlayer> Players { get; set; }
        public LeagueStats Stats { get; set; }
    }

    public class LeagueFounder
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class LeagueSeason
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
    }

    public class LeagueTeam
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class LeaguePlayer
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class LeagueStats
    {

    }
}
