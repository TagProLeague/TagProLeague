interface TeamModel {
    id: number;
    name: string;
    startedOn: string;
    endedOn: string;
    founder: TeamFounder;
    status: string;
	currentSeason: string;
	fullName: string;
    seasons: TeamSeason[];
}

interface TeamFounder {
    name: string;
}

interface TeamSeason {
    name: string;
}