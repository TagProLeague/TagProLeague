interface LeagueModel {
    id: number;
    name: string;
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
}