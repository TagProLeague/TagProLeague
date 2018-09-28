using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace TagProLeague.Models
{
    public class MongoDbLeague
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public string CreatedOn { get; set; }
        public string StartedOn { get; set; }
        public string EndedOn { get; set; }
        public List<LeagueSeasonPreview> SeasonPreviews { get; set; }
        public List<LeagueTeamPreview> TeamPreviews { get; set; }
        public List<LeaguePlayerPreview> PlayerPreviews { get; set; }
        public LeagueStats Stats { get; set; }
    }

    public class League
    {
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public string CreatedOn { get; set; }
        public string StartedOn { get; set; }
        public string EndedOn { get; set; }
        public List<LeagueSeasonPreview> SeasonPreviews { get; set; }
        public List<LeagueTeamPreview> TeamPreviews { get; set; }
        public List<LeaguePlayerPreview> PlayerPreviews { get; set; }
        public LeagueStats Stats { get; set; }
    }

    public class LeagueSeasonPreview
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class LeagueTeamPreview
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class LeaguePlayerPreview
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class LeagueStats
    {

    }
}
