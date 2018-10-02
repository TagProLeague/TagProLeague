interface LeagueModel {
    id: number;
    name: string;
    abbreviation: string;
    startedOn: string;
    endedOn: string;
    founder: LeagueFounder;
    status: string;
    currentSeason: string;
    seasons: LeagueSeason[];
}

interface LeagueFounder {
    name: string;
}

interface LeagueSeason {
    name: string;
    abbreviation: string;
}